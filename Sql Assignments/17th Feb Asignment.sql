--Create Proc sp_InsertDataIntoEmployee
--(@EmpNo int,@EmpName varchar(100),@Salary int,@DeptNo int,@Designation varchar(100))
--As
--Begin
--   if(dbo.[ValidateData](@EmpNo,@EmpName,@Salary,@DeptNo)=1)
--   insert into Employee values(@EmpNo,@EmpName ,@Salary,@DeptNo,@Designation)
--   else
--   print'Invalid Data'
--End;

exec sp_InsertDataIntoEmployee 159,'Dha2rshini',23900,20,'Staff';
GO

select * from Employee where Salary =(select  MAx(Salary) from Employee) 
