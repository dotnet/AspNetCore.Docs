var students = from s in studentRepository.GetStudents()
               select s;