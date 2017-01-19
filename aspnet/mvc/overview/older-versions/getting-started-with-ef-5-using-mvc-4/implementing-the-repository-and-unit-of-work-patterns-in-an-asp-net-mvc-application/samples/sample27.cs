public GenericRepository<Department> DepartmentRepository
{
    get
    {

        if (this.departmentRepository == null)
        {
            this.departmentRepository = new GenericRepository<Department>(context);
        }
        return departmentRepository;
    }
}