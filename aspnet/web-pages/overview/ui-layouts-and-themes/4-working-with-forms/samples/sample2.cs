@{
    if (IsPost) {
        string companyname = Request.Form["companyname"];
        string contactname = Request.Form["contactname"];
        int employeecount = Request.Form["employees"].AsInt();

        <text>
          You entered: <br />
          Company Name: @companyname <br />
          Contact Name: @contactname <br />
          Employee Count: @employeecount <br />
        </text>
    }
}