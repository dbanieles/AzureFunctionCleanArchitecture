
# Aure Function Clean Architetture

 ``` 
 dotnet pack ./nuget.csproj
 dotnet new -i ./AzureFunctionCleanArchitetture.1.0.0.nupkg
 dotnet new --uninstall AzureFunctionCleanArchitetture  
 ``` 

# CLI Command

To learn more, run the following command:
```bash
dotnet new azfca-sln --help
```

You can create use cases (commands or queries) by navigating to `./src/Application` and running `dotnet new ca-usecase`. Here are some examples:

To create a new command:
```bash
dotnet new azfca-usecase --name CreateTodoList --feature-name TodoLists --usecase-type command --return-type int
```

To create a query:
```bash
dotnet new azfca-usecase -n GetTodos -fn TodoLists -ut query -rt TodosVm
```

To learn more, run the following command:
```bash
dotnet new azfca-usecase --help
```