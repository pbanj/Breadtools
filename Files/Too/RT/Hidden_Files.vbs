@ECHO OFF

REM Script by GoodDayToDie of XDA-Developers. Can be run as standard user

SETLOCAL

REM Check the registry for a specific value. Findstr will set errorlevel to 0 if found, 1 if not

REG QUERY HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced /v Hidden | findstr 0x2 > NUL
IF ERRORLEVEL 1 (

	REM The value was not 2, so set it to 2 (for "Hidden" only)

	REG ADD HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced /v Hidden /t REG_DWORD /d 2 /f > NUL
	REG ADD HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced /v ShowSuperHidden /t REG_DWORD /d 1 /f > NUL
) ELSE (

	REM The value was 2, so set it to 1

	REG ADD HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced /v Hidden /t REG_DWORD /d 1 /f > NUL
	REG ADD HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced /v ShowSuperHidden /t REG_DWORD /d 1 /f > NUL
)
ENDLOCAL