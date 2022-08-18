GeeksForLessForum

To run this program, you need to enter the following commands in nuget manager:
add-migration User -Context UserDbContext
add-migration Post -Context PostDbContext
add-migration Topic -Context TopicDbContext

after that

update-database User -Context UserDbContext
update-database Post -Context PostDbContext
update-database Topic -Context TopicDbContext