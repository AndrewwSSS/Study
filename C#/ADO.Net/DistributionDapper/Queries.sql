select top(3) s.Name, Count(i.SectionId)
from Interests i, Sections s
where(i.SectionId = s.id)
group by i.SectionId, s.Name
order by 2 desc


select top(1) s.Name, Count(i.SectionId)
from Interests i, Sections s
where(i.SectionId = s.id)
group by i.SectionId, s.Name
order by 2 desc



select top(3) s.Name, Count(i.SectionId)
from Interests i, Sections s
where(i.SectionId = s.id)
group by i.SectionId, s.Name
order by 2 asc



select top(1) s.Name, Count(i.SectionId)
from Interests i, Sections s
where(i.SectionId = s.id)
group by i.SectionId, s.Name
order by 2 asc














select top(3) S.Name, Count(P.SectionId)
from promotionalProducts Pp, Products P, Sections S
where(P.id = Pp.ProductId and S.id = P.SectionId)
group by P.SectionId, S.Name
order by 2 desc


select top(1) S.Name, Count(P.SectionId)
from promotionalProducts Pp, Products P, Sections S
where(P.id = Pp.ProductId and S.id = P.SectionId)
group by P.SectionId, S.Name
order by 2 desc


select top(3) S.Name, Count(P.SectionId)
from promotionalProducts Pp, Products P, Sections S
where(P.id = Pp.ProductId and S.id = P.SectionId)
group by P.SectionId, S.Name
order by 2 asc


select top(1) S.Name, Count(P.SectionId)
from promotionalProducts Pp, Products P, Sections S
where(P.id = Pp.ProductId and S.id = P.SectionId)
group by P.SectionId, S.Name
order by 2 asc









select distinct P.Name, P.Price, Pp.NewPrice, Pp.DateStart, Pp.DateEnd, Pp.Country
from PromotionalProducts Pp, Products p
where((DATEDIFF(day, getdate(), Pp.DateEnd ) = 3) and Pp.ProductId = P.id)


select distinct P.Name, P.Price, Pp.NewPrice, Pp.DateStart, Pp.DateEnd, Pp.Country
from PromotionalProducts Pp, Products P
where(DATEDIFF(day, getdate(), Pp.DateEnd ) < 0)


alter procedure [dbo].ArchivetePp
as
begin
	declare @tmp table(id int, ProductId int, NewPrice bigint, DateStart date, DateEnd date, Country nvarchar(100))
	set IDENTITY_INSERT [dbo].PromotionalProductsArchive on;

	insert into @tmp(id, ProductId, NewPrice, DateStart, DateEnd, Country)
		select id, ProductId, NewPrice, DateStart, DateEnd, Country
		from [dbo].PromotionalProducts
		where(DATEDIFF(day, getdate(), DateEnd ) < 0)

	Delete
	from promotionalProducts
	where(promotionalProducts.id = any(select id from @tmp))

	insert into [dbo].PromotionalProductsArchive(id, ProductId, NewPrice, DateStart, DateEnd, Country)
		select id, ProductId, NewPrice,  DateStart, DateEnd, Country
		from @tmp
	return @@ROWCOUNT 
end;


declare @result int;
exec @result = [dbo].ArchivetePp;
select @result as 'result';


select S.Name, Avg(DATEDIFF(YEAR, C.DateOfbirth,  getdate())) as 'AvgAge'
from Customers C, Interests I, Sections S
where(S.id = I.SectionId and I.CustomerId = C.id)
group by S.Name


select C.CountryOfResidence, Avg(DATEDIFF(YEAR, C.DateOfbirth,  getdate()))
from Customers C
group by C.CountryOfResidence












select top(1) S.Name as 'Top 1 sections for womens'
from Customers C, Interests I, Sections S
where(C.id = I.CustomerId and S.id = I.SectionId and C.Sex = 0)
group by C.Sex, S.Name
order by Count(I.SectionId) desc

select top(1) S.Name as 'Top 1 sections for mans'
from Customers C, Interests I, Sections S
where(C.id = I.CustomerId and S.id = I.SectionId and C.Sex = 1)
group by C.Sex, S.Name
order by Count(I.SectionId) desc



select top(3) S.Name as 'Top 3 sections for womens'
from Customers C, Interests I, Sections S
where(C.id = I.CustomerId and S.id = I.SectionId and C.Sex = 0)
group by C.Sex, S.Name
order by Count(I.SectionId) desc

select top(3) S.Name as 'Top 3 sections for mans'
from Customers C, Interests I, Sections S
where(C.id = I.CustomerId and S.id = I.SectionId and C.Sex = 1)
group by C.Sex, S.Name
order by Count(I.SectionId) desc


select Count(C.Sex) as 'NumberOfWomens' 
from Customers C
where(C.Sex = 0)


select Count(C.Sex) as 'NumberOfMans' 
from Customers C
where(C.Sex = 1)


select C.CountryOfResidence, Count(C.id) as 'NumberOfWomens'
from Customers C
where(C.Sex = 0)
group by C.CountryOfResidence


select C.CountryOfResidence, Count(C.id) as 'NumberOfMans'
from Customers C
where(C.Sex = 1)
group by C.CountryOfResidence