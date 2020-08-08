update procedure [dbo].[spRoomTypes_GetById]
    @id int
    
    as 
    begin 
        set nocount on;
        
        select *
        from dbo.RoomTypes
        where Id = @id;
    end
go

