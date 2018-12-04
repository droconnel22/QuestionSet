Select UA.UserId, 
(CASE
	WHEN
		DATEDIFF (minute, 
		(SELECT UA2.Timestamp
						from dbo.UserActivity UA2
						WHERE  UA.UserId = UA2.UserId and UA2.Action ='LoggedIn'),
		(select UA1.Timestamp
						from dbo.UserActivity UA1
						where UA.UserId = UA1.UserId and UA1.Action = 'Clicked')			
		) IS NULL 
		
	THEN
		DATEDIFF (minute, 
		(SELECT UA2.Timestamp
						from dbo.UserActivity UA2
						WHERE  UA.UserId = UA2.UserId and UA2.Action ='LoggedIn'),
		(select UA1.Timestamp
						from dbo.UserActivity UA1
						where UA.UserId = UA1.UserId and UA1.Action = 'LoggedOut')			
		)
	ELSE 
	DATEDIFF (minute, 
		(SELECT UA2.Timestamp
						from dbo.UserActivity UA2
						WHERE  UA.UserId = UA2.UserId and UA2.Action ='LoggedIn'),
		(select UA1.Timestamp
						from dbo.UserActivity UA1
						where UA.UserId = UA1.UserId and UA1.Action = 'Clicked')			
		)
END
)
AS "LoggedIn",
DATEDIFF (minute, 
(SELECT UA2.Timestamp
                from dbo.UserActivity UA2
                WHERE  UA.UserId = UA2.UserId and UA2.Action ='Clicked'),
(select UA1.Timestamp
                from dbo.UserActivity UA1
                where UA.UserId = UA1.UserId and UA1.Action = 'LoggedOut')			
				) AS "Clicked",
NULL as "LoggedOut" 
from dbo.UserActivity as UA
Group by UA.UserId