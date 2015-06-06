create procedure create_doc(_id int, _day int, _month int, _year int, _idw int, _idp int, _idg int, _amount int)
begin 
insert into dbo.Invoices(id_invoice, day_invoice, month_invoice, year_invoice, id_worker, id_provider, id_good, amount_good) 
values(_id, _day, _month, _year, _idw, _idp, _idg, _amount);
end