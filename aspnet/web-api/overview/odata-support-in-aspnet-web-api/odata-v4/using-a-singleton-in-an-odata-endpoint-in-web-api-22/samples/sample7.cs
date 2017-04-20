// Get Singleton 
// ~/singleton 
public IHttpActionResult Get() 
public IHttpActionResult GetUmbrella() 

// Get Singleton 
// ~/singleton/cast 
public IHttpActionResult GetFromSubCompany() 
public IHttpActionResult GetUmbrellaFromSubCompany() 

// Get Singleton Property 
// ~/singleton/property  
public IHttpActionResult GetName() 
public IHttpActionResult GetNameFromCompany() 

// Get Singleton Navigation Property 
// ~/singleton/navigation  
public IHttpActionResult GetEmployees() 
public IHttpActionResult GetEmployeesFromCompany() 

// Update singleton by PUT 
// PUT ~/singleton 
public IHttpActionResult Put(Company newCompany) 
public IHttpActionResult PutUmbrella(Company newCompany) 

// Update singleton by Patch 
// PATCH ~/singleton 
public IHttpActionResult Patch(Delta<Company> item) 
public IHttpActionResult PatchUmbrella(Delta<Company> item) 

// Add navigation link to singleton 
// POST ~/singleton/navigation/$ref 
public IHttpActionResult CreateRef(string navigationProperty, [FromBody] Uri link) 

// Delete navigation link from singleton 
// DELETE ~/singleton/navigation/$ref?$id=~/relatedKey 
public IHttpActionResult DeleteRef(string relatedKey, string navigationProperty) 

// Add a new entity to singleton navigation property 
// POST ~/singleton/navigation 
public IHttpActionResult PostToEmployees([FromBody] Employee employee) 

// Call function bounded to singleton 
// GET ~/singleton/function() 
public IHttpActionResult GetEmployeesCount()