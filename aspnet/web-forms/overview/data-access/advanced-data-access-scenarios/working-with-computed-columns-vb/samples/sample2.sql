(((([ContactName]+' (')+case when [ContactTitle] IS NOT NULL 
    then [ContactTitle]+', ' else '' end)+[CompanyName])+')')