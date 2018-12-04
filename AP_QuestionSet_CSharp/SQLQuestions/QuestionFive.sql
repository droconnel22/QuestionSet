SELECT
UA.UserId,
UD.FirstName + ' ' + UD.LastName as 'Name',
Max(CAST(UA.Timestamp AS DATE))
FROM dbo.UserActivity as UA
INNER JOIN
dbo.UserData as UD
ON
UA.UserId = UD.Id
GROUP BY UA.UserId,UD.FirstName + ' ' + UD.LastName