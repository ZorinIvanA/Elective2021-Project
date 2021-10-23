SELECT 
	b.id, 
	b.name, 
	a.name author_name, 
	p.name publisher_name, 
	published_year, 
	pages_count 
FROM Books b JOIN [dbo].[Authors] a 
	ON b.author_id=a.id
JOIN publishers p ON b.publisher_id=p.id
WHERE p.id = 3 AND a.id=1
ORDER BY name DESC

SELECT a.name author_name, COUNT(b.id) AS books_count 
FROM Books b JOIN [dbo].[Authors] a 
	ON b.author_id=a.id
GROUP BY a.name 

SELECT p.name, COUNT(b.id) AS books_count
FROM books b JOIN publishers p 
	ON b.publisher_id = p.id
WHERE published_year>2015
GROUP BY p.name

SELECT a.name author_name, COUNT(b.id) AS books_count, AVG(pages_count) AS pages_count 
FROM Books b JOIN [dbo].[Authors] a 
	ON b.author_id=a.id
GROUP BY a.name
HAVING COUNT(b.id)>=2