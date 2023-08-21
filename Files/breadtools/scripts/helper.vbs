Set shell = WScript.CreateObject("Shell.Application")
     executable = WSCript.Arguments(0)
     folder = WScript.Arguments(1)
     If Wscript.Arguments.Count > 2 Then
         profile = WScript.Arguments(2)
         shell.ShellExecute "powershell", "Start-Process \""" & executable & "\"" -ArgumentList \""-p \""\""" & profile & "\""\"" -d \""\""" & folder & "\""\"" \"" ", "", "runas", 0
     Else
         shell.ShellExecute "powershell", "Start-Process \""" & executable & "\"" -ArgumentList \""-d \""\""" & folder & "\""\"" \"" ", "", "runas", 0
     End If
