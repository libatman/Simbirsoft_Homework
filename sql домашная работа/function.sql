create function get_worker (month_s int, yaer_s int)
returns int
begin
declare int_worker int
select MAX(Salaries.amount_supplies), Salaries.id_worker
from Salaries
where Salaries.month_salary = month_s AND year_salary = year_s;
return int_worker;
end