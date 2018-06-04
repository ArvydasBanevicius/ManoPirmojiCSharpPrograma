select [DeviceTime],[Energy],[Volume],[Flow],[Power],[T1],[T2],[dT],[OnTime],[Error] 
from 
( 
  select ReadingTime, DeviceData, ParameterName, DimensionName from DataCollection  
	inner join DeviceList on DataCollection.DeviceID = DeviceList.Id 
	inner join Parameter on DataCollection.ParameterID = Parameter.Id 
	inner join Dimension on DataCollection.DimensionID = Dimension.Id 
  where (DeviceList.Id = 1) 
) src 
pivot 
( 
  max(DeviceData) 
  for ParameterName in([DeviceTime],[Energy],[Volume],[Flow],[Power],[T1],[T2],[dT],[OnTime],[Error]) 
) pvt 