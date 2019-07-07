This will install a menu to your context(right click) menu.  
Items include regedit, open cmd here(normal and admin) show/hide known file types, show/hide hidden files/folders, open bash here, open admin powershell here, and open powershell here.

**Newest ver may only work fully on windows 10 with the newest "features" update, as I update it with any changes needed after each one.**
Here is an older ver that will work on windows 8/8.1 and should work on 7: [Tools_menu.zip](https://cdn.discordapp.com/attachments/246402376099954689/288882232892981249/Tools_Menu.zip)


**HOW TO USE:**

1. Run Tools.bat as admin
2. Follow what it says
3. If icons dont show up reboot or restart explorer

if you want to use open bash here you need to follow [enable the linux subsystem](https://msdn.microsoft.com/en-us/commandline/wsl/install_guide).

If you would like take ownership in your context menu you will find it in the "take ownership" folder. 

**What the tool menu looks like with all options**


![Tools](https://i.imgur.com/YJcfjSb.png)


**What the power menu looks like with all options**


![Power](http://i.imgur.com/d7gK35h.png)

**What the settings menu looks like**

![settings](https://i.imgur.com/9epxxU5.png)


**Changelog:**

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