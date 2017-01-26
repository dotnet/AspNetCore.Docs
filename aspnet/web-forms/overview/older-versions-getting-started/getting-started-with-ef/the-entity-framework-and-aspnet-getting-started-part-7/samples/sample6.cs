var allCourses = (from c in context.Courses
				  select c).ToList();