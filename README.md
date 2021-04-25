# medyana-services

## Description 
Xml files read from static path <b>"C:\Projects\StaticFiles\XmlFiles"</b> <br>
Producer console app transfer files to consumer console app via RabbitMq <br>
Consumer console app parse xml files then post to api <br>
Api implemented for crud operations of patient data to mssql db <br>
Errors and info data logged to console and file via Serilog <br>
Sample xml files added <br>
Db Connection string stored in appsettings.json file in api<br>
Ef Migrations should be run<br>
SignalR used for notify added data to Medyana-UI<br>
Medyana-UI should run after services to connect via SignalR
