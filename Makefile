CSC=dotnet
projname=zicat
tgtversion=7.0
tgtsys=win-x64
bin=bin/Debug/net$(tgtversion)/$(tgtsys)/$(projname).dll
CSC_flags=--runtime $(tgtsys) --self-contained

build:
	@ echo Restoring $(projname)...
	$(CSC) restore
	@ echo Building $(projname)...
	$(CSC) build $(CSC_flags)

run:
	@ dotnet $(bin)