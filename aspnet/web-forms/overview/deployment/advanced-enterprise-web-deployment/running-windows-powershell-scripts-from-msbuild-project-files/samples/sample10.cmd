powershell.exe -NonInteractive -executionpolicy Unrestricted 
               -command &quot;&amp; Invoke-Command 
                 –ComputerName &apos;REMOTESERVER1&apos;
                 -ScriptBlock { &amp;&apos;C:\Path With Spaces\LogDeploy.ps1&apos; 
                                &apos; C:\Path With Spaces\Log.txt &apos;  
                                &apos;TESTWEB1&apos; } &quot;