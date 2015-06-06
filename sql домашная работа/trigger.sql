create trigger count_extra after insert on Invoices
begin
update Salaries set salary = salary + 50,
amount_supplies = amount_supplies + 1
where Invoices.month_invoice = Salaries.month_salary and
Invoices.year_invoice = Salaries.year_salary and
Invoices.id_worker = Salaries.id_worker;
end;