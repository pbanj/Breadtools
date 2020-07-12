This will install a menu to your context(right click) menu.  
Items include regedit, open cmd here(normal and admin) show/hide known file types, show/hide hidden files/folders, open bash here, and open powershell here(normal and admin)

This is meant for advanced users who are comfortable editing registry files as this is very much an alpha

- Admin terminals made possible from a script from https://github.com/lextm/windowsterminal-shell

**YOU MUST EDIT THE INSTALL REGISTRY FILE FOR THE POSISTION YOU WANT**
1. Open it in a text editor. search for `replace` and replace it with your windows username
example:
change 
`[HKEY_CLASSES_ROOT\Directory\ContextMenus\Tools\winterm\shell\1cmd\command]
@="\"C:\\Users\\replace\\AppData\\Local\\Microsoft\\WindowsApps\\wt.exe\" -p \"Command Prompt\" -d \"%V.\""`

to 
`[HKEY_CLASSES_ROOT\Directory\ContextMenus\Tools\winterm\shell\1cmd\command]
@="\"C:\\Users\\pbanj\\AppData\\Local\\Microsoft\\WindowsApps\\wt.exe\" -p \"Command Prompt\" -d \"%V.\""`

2. Save the file

**YOU MUST HAVE WSL AND WINDOWS TERMINAL INSTALLED FROM THE WINDOWS STORE**
- This was only tested with Ubuntu. If you use a different distro you'll have to change all mentions of `Ubuntu` in the install file like you did with your user name
- You may have to change your default settings for windows terminal located `%localappdata%\Packages\Microsoft.WindowsTerminal_8wekyb3d8bbwe\LocalState\settings.json`
change the `"startingDirectory"` option to `"startingDirectory": "."` and save the file.

**HOW TO USE:**
1. Uninstall old tools menu(you can leave settings and power if you use them)
2. Clone the repo
3. Run Tools.bat as admin
4. Follow what it says
5. If icons don't show up reboot or restart explorer


**Changelog:**
0.00000000069 testing
0.000000069 move settings, add sfc /scannow, and update icons(thanks to ghostboy)