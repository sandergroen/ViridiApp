build:
	dotnet build
clean:
	dotnet clean
restore:
	dotnet restore
watch:
	dotnet watch --project src/ViridiApp.Web/ViridiApp.Web.csproj
run:
	dotnet run --project src/ViridiApp.Web/ViridiApp.Web.csproj
