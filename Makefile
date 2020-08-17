CS = csc
CS_SCRIPTS = $(shell dir /s /b | find ".cs")

PROJ_NAME = JiYu-the-hack

all:
	$(CS) /out:debug.exe $(CS_SCRIPTS)

run:
	$(CS) /out:debug.exe $(CS_SCRIPTS)
	debug.exe
build:
	$(CS) /out:$(PROJ_NAME).exe /platform:x86 /icon:resources/icon.png $(CS_SCRIPTS)