@echo off
goto check_Permissions

:check_Permissions
    
    net session >nul 2>&1
    if %errorLevel% == 0 (
        echo off
    ) else (
        echo Im sorry %username%, but I cant let you do that.
		echo I know reading is hard but come on, it's a small text file. Go RTFM.
		echo If this was a 3ds you'd have bricked.
pause
exit
    )

@echo off

CLS

:start
cls
echo Welcome %username%, this will install the tools, settings menu, and a power menu.
echo 1. Install
echo 2. Uninstall
echo 3. Exit
set /P A=Choose 1, 2, or 3 then press enter. 
if %A%==1 goto pos
if %A%==2 goto unin
if %A%==3 exit
goto start

:pos
:start_pos
cls
echo Choose position
echo 1. Normal
echo 2. Top
echo 3. bottom
set /P A=Choose position then press enter. 
if %A%==1 goto all
if %A%==2 goto tall
if %A%==3 goto ball
goto start_pos

:all
cd /d %~dp0
REGEDIT /s Files\Installers\tools_and_settings_install.reg
robocopy Files\Breadtools C:\Breadtools /E
goto bicons

:tall
cd /d %~dp0
REGEDIT /s Files\Installers\top_tools_and_settings_install.reg
robocopy Files\Breadtools C:\Breadtools /E
goto bicons

:ball
cd /d %~dp0
cd /d %~dp0
REGEDIT /s Files\Installers\bottom_tools_and_settings_install.reg
robocopy Files\Breadtools C:\Breadtools /E
goto bicons

:bicons
:start_bicons
cls
echo Which distro do you use for WSL?
echo 1. Ubuntu
echo 2. Debian
echo 3. Kali
echo 4. Suse
set /P A=Choose one then press enter. 
if %A%==1 goto ub
if %A%==2 goto de
if %A%==3 goto ka
if %A%==4 goto su
goto start_bicons

:ub
cd /d %~dp0
robocopy Files\Bash\Ubuntu C:\Breadtools\icons
goto powr

:de
cd /d %~dp0
robocopy Files\Bash\Debian C:\Breadtools\icons
goto powr

:ka
cd /d %~dp0
robocopy Files\Bash\Kali C:\Breadtools\icons
goto powr

:su
cd /d %~dp0
robocopy Files\Bash\Suse C:\Breadtools\icons
goto powr

:powr
cls
echo %username% would you like to install the power menu also?
echo 1. yes
echo 2. no
set /P A=Choose one then press enter.
if %A%==1 goto powri
if %A%==2 goto done
goto powr

:powri
cls
robocopy Files\Power C:\Breadtools\icons\power
REGEDIT /s Files\Installers\pwrinstall.reg
goto done

:unin
cls
:start_unin
echo Uninstall
echo 1. Uninstall just tools?
echo 2. Uninstall just settings?
echo 3. Uninstall just power?
echo 4. Uninstall everything?
set /P A=Choose what to uninstall then press enter. 
if %A%==1 goto utol
if %A%==2 goto uset
if %a%==3 goto upow
if %A%==4 goto evthang
goto start_unin

:utol
cd /d %~dp0
REGEDIT /s Files\Uninstallers\tooluninstall.reg
del C:\Breadtools\icons\tools.ico C:\Breadtools\icons\terminal.ico C:\Breadtools\icons\file.ico C:\Breadtools\icons\bash.ico
echo Done Uninstalling. Have a fucked day %username%.
pause
exit

:uset
cd /d %~dp0
REGEDIT /s Files\Uninstallers\settinguninstall.reg
del C:\Breadtools\icons\settings.ico C:\Breadtools\icons\update.ico C:\Breadtools\icons\system.ico C:\Breadtools\icons\network.ico
echo Done Uninstalling. Have a fucked day %username%.
pause
exit

:upow
cd /d %~dp0
REGEDIT /s Files\Uninstallers\uninstallpow.reg
rmdir /s C:\Breadtools\power
echo Done Uninstalling. Have a fucked day %username%.
pause
exit

:evthang
cd /d %~dp0
REGEDIT /s Files\Uninstallers\evthang.reg
rmdir /s C:\Breadtools\
echo Done Uninstalling. Have a fucked day %username%.
pause
exit

:done
cls
echo Done installing. Have a fucked day %username%.
pause
exit