<a name="test"></a>

### Test the app

* Run the app and append `/Movies` to the URL in the browser (`http://localhost:port/movies`).
* Test the **Create** link.

  ![Create page](../../tutorials/razor-pages/model/_static/conan.png)

<a name="scaffold"></a>

* Test the **Edit**, **Details**, and **Delete** links.

If you get the following error, verify you have run migrations and updated the database:

```
An unhandled exception occurred while processing the request.
SqliteException: SQLite Error 1: 'no such table: Movie'.
Microsoft.Data.Sqlite.SqliteException.ThrowExceptionForRC(int rc, sqlite3 db)
```
