> Some commands aren't supported if the app uses SQLite as its Identity data store. Due to limitations in the database engine, 
> `Alter` commands throw the following exception:
>
> "System.NotSupportedException: SQLite does not support this migration operation." 
>
> As a work around, run Code First migrations on the database to change the tables.
