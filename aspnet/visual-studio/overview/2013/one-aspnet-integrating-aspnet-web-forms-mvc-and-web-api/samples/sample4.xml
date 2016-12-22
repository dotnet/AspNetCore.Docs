...

// POST: /MvcPerson/Create
// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<ActionResult> Create([Bind(Include="Id,Name,Age")] Person person)
{
     if (ModelState.IsValid)
     {
          db.People.Add(person);
          await db.SaveChangesAsync();
          return RedirectToAction("Index");
     }

     return View(person);
}

// GET: /MvcPerson/Edit/5
public async Task<ActionResult> Edit(int? id)
{
     if (id == null)
     {
          return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
     }
     Person person = await db.People.FindAsync(id);
     if (person == null)
     {
          return HttpNotFound();
     }
     return View(person);
}

...