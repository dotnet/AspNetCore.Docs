vsdbcmd.exe /a:Deploy
            /manifest:"…\ContactManager.Database.deploymanifest"
            /cs:"Data Source=TESTDB1;Integrated Security=true"
            /p:TargetDatabase=ContactManager
            /dd-
            /script:"…\Publish-ContactManager-Db.sql"