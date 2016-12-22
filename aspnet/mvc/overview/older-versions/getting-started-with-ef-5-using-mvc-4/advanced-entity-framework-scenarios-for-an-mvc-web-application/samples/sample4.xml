var query = "SELECT EnrollmentDate, COUNT(*) AS StudentCount "
    + "FROM Person "
    + "WHERE EnrollmentDate IS NOT NULL "
    + "GROUP BY EnrollmentDate";
var data = db.Database.SqlQuery<EnrollmentDateGroup>(query);