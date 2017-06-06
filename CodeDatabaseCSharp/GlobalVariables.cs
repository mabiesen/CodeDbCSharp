using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeDatabaseCSharp
{
    public static class GlobalVariables
    {
        //THIS IS THE CLASS FOR ALL VARIABLES THAT NEED TO BE PASSED ACROSS FORMS
        //THIS CLASS ALSO CONTAINS METHODS FOR THOSE VARIABLES AS WELL AS SQL STATEMENTS
        //This class also contains a list of forms for closing purposes
        //Note: SQL statements and methods may be moved to a separate file give their singular functionality

        public static List<Form> formList = new List<Form>();
        
        public static void addAForm(Form newForm)
        {
            formList.Add(newForm);
        } 

        public static void closeToMainMenu()
        {
            int count = formList.Count;
            for(int ctr = count - 1; ctr >= 0; ctr--)
            {
                formList[ctr].Close();
            }
        }

        //Variables that house each of our indexers.
        public static FunctionsIndexer databaseFunctions = new FunctionsIndexer();
        public static FunctionsIndexer libraryFunctions = new FunctionsIndexer();
        public static FunctionsIndexer fileFunctions = new FunctionsIndexer();

        //Needed a way to pass selected language back to main form for file language identification
        public static string userFileLanguage = "";

        //Variables for use with datagrid
        //activetable will be our datasource for the datagrid
        //activeTableIndicator will be used to indicate to the form which indexer we are going to play with
        //public static DataTable activeTable = new DataTable();
        public static string activeTableIndicator = "";
        public static DataTable activeTable = new DataTable();

        //Variables for use with individual function page
        //active function index used to cycle through a given list
        //active function indicator used to indicate which index we are going to play with. if "NONE", no lists referenced as its a new function
        //NOTE: active function indicator will be "NONE","FILE","LIBRARY","DATABASE"
        public static individualFunction activeFunctionFunction = new individualFunction();
        public static int activeFunctionIndex = 0;
        public static string activeFunctionIndicator = "";
        public static FunctionsIndexer activeFunctionList = new FunctionsIndexer();

        //Variables for use with sql connection
        public static string awsConnectionString = @"Data Source=myfirstproject.cp8qvjgtobrv.us-west-2.rds.amazonaws.com,1433;Database=FunctionsDatabase; Persist Security Info=True; User ID=mabiesen; PWD=D!tchH3LL;";
        public static string globalConnectionString = @"Data Source=DESKTOP-8RM4FLT\SQLEXPRESS;Database=FunctionsDatabase;Integrated Security=True";
        public static List<string> globalTableWhitelist = new List<string>{ "FunctionImportsTable", "FunctionMainTable", "FunctionTagsTable" };
        public static List<string> globalFieldWhitelist = new List<string> { "Prototype", "ID", "Language", "WholeFunction", "Purpose", "Tags", "Imports" };
        public static string selectAllData = "SELECT " +
        "FunctionMainTable.Prototype, " + "FunctionMainTable.Purpose, " + "FunctionMainTable.WholeFunction, " + "FunctionMainTable.Language, " +
        "Imports=STUFF((SELECT ','+ Imports FROM FunctionImportsTable WHERE Prototype=FunctionMainTable.Prototype FOR XML PATH('')) , 1 , 1 , '' ), " +
        "Tags=STUFF((SELECT ','+ Tags FROM FunctionTagsTable WHERE Prototype=FunctionMainTable.Prototype FOR XML PATH('')) , 1 , 1 , '' ) " +
        "FROM FunctionMainTable";
        public static BasicSQLClass myNewSql = new BasicSQLClass(awsConnectionString, globalTableWhitelist, globalFieldWhitelist);

        //This function is used to set the actifFunctionList
        public static void setActiveFunctionList()
        {
            switch (activeFunctionIndicator)
            {
                case "DATABASE":
                    activeFunctionList.replaceFunctionsList(databaseFunctions.functionList);
                    break;
                case "FILE":
                    activeFunctionList.replaceFunctionsList(fileFunctions.functionList);
                    break;
                case "LIBRARY":
                    activeFunctionList.replaceFunctionsList(libraryFunctions.functionList);
                    break;
                case "NONE":
                    //In the case of NONE, there is no named indexer.  We just replace activeFunctionList with ONE blank function.
                    individualFunction tempFunction = new individualFunction();
                    tempFunction.ClearAll();
                    List<individualFunction> tempList = new List<individualFunction>();
                    tempList.Add(tempFunction);
                    activeFunctionList.replaceFunctionsList(tempList);
                    break;
                    
            }
        }

        //Sync the function indexers to active function list  UNUSED????
        //NOTE: not desired for database because database should be refreshed upon each viewing
        //NOTE: not desired for files as files should not change; they are merely a delivery mechanism
        public static void syncIndexerToActiveFunctionList()
        {
            switch (activeFunctionIndicator)
            {
                case "LIBRARY":
                    libraryFunctions.replaceFunctionsList(activeFunctionList.functionList);
                    break;
            }
        }

        //set the active table for viewing in our datagrid
        public static void setActiveTable()
        {
            activeTable.Clear();
            switch (activeTableIndicator)
            {
                case "DATABASE":
                    activeTable = databaseFunctions.createFunctionTable();
                    break;
                case "FILE":
                    activeTable = fileFunctions.createFunctionTable();
                    break;
                case "LIBRARY":
                    activeTable = libraryFunctions.createFunctionTable();
                    break;

            }
        }

        //SQL execute database queries to remove from each table
        public static void removeFromDatabase()
        {
            myNewSql.DelAllSelectedOneCriteria("FunctionImportsTable",activeFunctionFunction.myPrototype,"Prototype");
            myNewSql.DelAllSelectedOneCriteria("FunctionTagsTable", activeFunctionFunction.myPrototype, "Prototype");
            myNewSql.DelAllSelectedOneCriteria("FunctionMainTable", activeFunctionFunction.myPrototype, "Prototype");
            refreshDatabaseIndexer();
        }

        //SQL add to each table
        public static void addToDatabase()
        {
            //Add to the function table
            string mainQuery = @"INSERT INTO FunctionMainTable VALUES ('" + activeFunctionFunction.myPrototype + "','" + activeFunctionFunction.myPurpose + "','" + activeFunctionFunction.myFunction + "','" + activeFunctionFunction.myLanguage + "')";
            myNewSql.GenericQuery(mainQuery);

            //Add to the imports table
            string importQuery = "";
            foreach (string thisimport in activeFunctionFunction.myImports)
            {
                importQuery = @"INSERT INTO FunctionImportsTable VALUES ('" + activeFunctionFunction.myPrototype + "','" + thisimport + "')";
                myNewSql.GenericQuery(importQuery);
                importQuery = "";
            }

            string tagQuery = "";
            foreach (string thistag in activeFunctionFunction.myTags)
            {
                tagQuery = @"INSERT INTO FunctionTagsTable VALUES ('" + activeFunctionFunction.myPrototype + "','" + thistag + "')";
                myNewSql.GenericQuery(tagQuery);
            }
            //Add to the database
            //Refresh the database indexer(i.e. get data from database)
            //Refresh the active indexer, refresh the active table.  Insures database information is most recent
            refreshDatabaseIndexer();
        }

        //Refresh both the table in the function review table and the indexer associated with function edit form
        public static void refreshDatabaseIndexer()
        {
            databaseFunctions.tableReplacesFunctionList(myNewSql.GetTableData(selectAllData));
            setActiveFunctionList();
            setActiveTable();
        }

    }
}
