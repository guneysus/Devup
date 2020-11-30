dotnet publish .\src\Devup\Devup.csproj `
	--configuration Release `
	--output build `
	-p:PublishReadyToRun=true `
	-p:PublishSingleFile=true `
	-p:PublishTrimmed=true `
	--self-contained true `
	--runtime win-x64 
	
	# -p:PublishReadyToRunShowWarnings=true
