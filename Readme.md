This will install up to 3 menus to your context(right click) menu.  
Items include regedit, open cmd here(normal and admin) show/hide known file types, show/hide hidden files/folders, open bash here, open powershell here(normal and admin), settings, environmental variables, and power options.


**Newest version may only work fully on windows 10 with the newest "features" update, as I update it with any changes needed after each one.**
Here is an older version that will work on windows 8/8.1 and should work on 7: [Tools_menu_8&8.1_final.zip](https://github.com/pbanj/tools-menu/blob/master/Tools_Menu_8%268.1_final.zip)  
Here is the final Pre-terminal version, based on this [commit](https://github.com/pbanj/tools-menu/commit/465fc305d9d5842e294f1111b449ea1c0d6a9841) [tools menu final.zip](https://github.com/pbanj/tools-menu/blob/master/tools%20menu%20final.zip)  


**YOU MUST HAVE WSL AND WINDOWS TERMINAL INSTALLED FROM THE WINDOWS STORE**
- This was only tested with Ubuntu. If you use a different distro you'll have to change `Ubuntu` to the one you use in the install file you plan to use. This will be fixed.

- You may have to change your default settings for windows terminal located `%localappdata%\Packages\Microsoft.WindowsTerminal_8wekyb3d8bbwe\LocalState\settings.json`
change the `"startingDirectory"` option to `"startingDirectory": "."` and save the file.



**HOW TO USE:**
1. Uninstall old tools menu this must be done if coming from v1.7 or any of the terminal alpha versions.
2. Download and extract it somewhere
3. Run Tools.bat as admin
4. Follow what it says
5. If icons don't show up restart explorer

![tools](https://i.imgur.com/EtEhJ2Q.png)  
![terminal](https://i.imgur.com/icl8EHV.png)  
![Scripts & Tools](https://i.imgur.com/n9shwiJ.png)  
![settings](https://i.imgur.com/1nD93K9.png)  


**Changelog:**  
2.0   
new name  
cleaned up batch file script  
updated icons  
make cmd, powershell, and bash go through windows terminal  
added more install & uninstall options  
moved all files out of C:\windows to C:\Breadtools
made it creepy ;)  
all the changes from the terminal alphas  

- terminal alpha 0.0069  
fixed a fuck up i caused   
clicking the settings option will now bring you to the main settings page instead of display   

- terminal alpha 0.00069   
redid menus to get around Microsoft's stupid fucking limit.
settings is now its own menu.
restart explorer, file types, sfc, and hidden files moved to a new sub menu under tools.
added environmental variables in the new "scripts & tools" sub-menu so you can edit your path easily.
clicking the "system" option in settings now brings you to about instead of display.
each time you click regedit it now opens a new window to make multitasking and editing easier.  

- terminal alpha 0.0000069 fix n++ fuckery
   
- terminal alpha 0.000000069 move settings, add sfc /scannow, and update icons(thanks to ghostboy)  

- terminal alpha 0.00000000069 testing  

- v1.7 - Cleaned up the admin cmd command to shut kip up.

- v1.6 - Forgot to change the bash reg files.

- v1.5 - Removed the need for powershell to open admin CMD. May cause issues if you have anything using the key in "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\runas" it will replace it with admin CMD. There's nothing on my pc that uses it as it is an alternate location than the standard "runas" key so it should be fine.

- v1.4 - Added distro selectable icons for bash.

- v1.3 - Removed gap in middle of settings menu.

- v1.2 - Added settings menu.

- v1.1 - Fixed admin cmd not working for some people.

- v1.0 - Fixed bash not opening, made bash optional for those that don't want it.

- v0.9 - Removed the need to open cmd first to open bash. take note that you must [enable the linux subsystem](https://msdn.microsoft.com/en-us/commandline/wsl/install_guide) for this to work.

- v0.8 - Added open bash here. take note that you must [enable the linux subsystem](https://msdn.microsoft.com/en-us/commandline/wsl/install_guide) for this to work.

- v0.7 - Fixed broken "Admin Cmd Here" for windows 10(thanks microsoft -_-), and added  "powershell here" for opening powershell in the current directory.

- v0.6 - Fixed missing power menu icons again.

- v0.5 - Fixed an issue in the hidden files vbs(thanks LEDelete for pointing it out), fixed missing icon folder copy command in install script (thanks trm96 for pointing that out) should fix icons not showing up.

- v0.4 - Added power menu. Normal has lock, logoff, restart, restart with boot options, and shut down. the second has all of the first but sleep, hibernate, and switch user.

- v0.3 - Able to remove the restart explorer.bat file thanks to coldbloc

- v0.2 - Added open powershell as admin here, fixed open cmd as admin here, no longer need ele.exe and the e.cmd files.



Contributors  
- [pbanj](https://github.com/pbanj) - Registry, and batch files
- [TurtleP](https://github.com/TurtleP) - GUI & Renaming script, coming up with the new name  
- [xGhostBoyx](https://github.com/xGhostBoyx) - Icons  
- [NotQuiteApex](https://github.com/NotQuiteApex) - I'm sure he's done something  
- [lexterm](https://github.com/lextm/windowsterminal-shell) - for making the admin terminals possible  
- [sevenforums](https://sevenforums.com) - extension, and hidden files VB scripts