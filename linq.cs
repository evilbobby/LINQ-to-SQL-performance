		public void PersonAction(int department, string message) {
            var people = (from p in db.Person
                              join j in db.Job on p.job_id equals j.id 
							  where j.department == department
                              select new {
										 FullName = p.first_name + " " + p.last_name,
										 JobID = p.job_id,
										 JobDesc = j.display,
										 Active = p.active
                              }).ToList(); //causes execution, prevents N+1 queries at the DB

            foreach (var person in people) { 
				if(person.Active) {
					SomeExternalFunction(person.FullName, person.JobID, person.JobDesc, message);
				} else {
					SomeOtherExternalFunction(person.FullName, person.JobID, person.JobDesc, message);
				}
            }
        }