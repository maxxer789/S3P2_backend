ù
\C:\Users\Max\Documents\GitHub\S3P2_backend\S3P2_project\GroupService\Context\GroupContext.cs
	namespace 	
GroupService
 
. 
Context 
{ 
public		 

class		 
GroupContext		 
:		 
	DbContext		  )
{

 
public 
GroupContext 
( 
DbContextOptions ,
<, -
GroupContext- 9
>9 :
options; B
)B C
:D E
baseF J
(J K
optionsK R
)R S
{ 	
} 	
} 
} Þ
cC:\Users\Max\Documents\GitHub\S3P2_backend\S3P2_project\GroupService\Controllers\GroupController.cs
	namespace 	
GroupService
 
. 
Controllers "
{ 
[		 
Route		 

(		
 
$str		 
)		 
]		 
[

 
ApiController

 
]

 
public 

class 
GroupController  
:! "

Controller# -
{ 
[ 	
HttpGet	 
] 
[ 	
Route	 
( 
$str 
) 
] 
public 
IActionResult 
Index "
(" #
)# $
{ 	
return 
View 
( 
) 
; 
} 	
} 
}  
bC:\Users\Max\Documents\GitHub\S3P2_backend\S3P2_project\GroupService\HubConfig\GroupMessagesHub.cs
	namespace 	
GroupService
 
. 
	HubConfig  
{ 
public		 

class		 
GroupMessagesHub		 !
:		" #
Hub		$ '
{

 
public 
async 
Task 
	AskServer #
(# $
string$ *
message+ 2
)2 3
{ 	
string 
tempMessage 
=  
$str! 3
;3 4
if 
( 
message 
!= 
$str  
)  !
{ 
tempMessage 
+= 
$str /
;/ 0
} 
else 
{ 
tempMessage 
+= 
message &
;& '
} 
await 
Clients 
. 
Clients !
(! "
this" &
.& '
Context' .
.. /
ConnectionId/ ;
); <
.< =
	SendAsync= F
(F G
$strG Z
,Z [
tempMessage\ g
)g h
;h i
} 	
public 
Task 
	JoinGroup 
( 
string $
	groupName% .
). /
{ 	
return 
Groups 
. 
AddToGroupAsync )
() *
Context* 1
.1 2
ConnectionId2 >
,> ?
	groupName@ I
)I J
;J K
} 	
public   
Task   

LeaveGroup   
(   
string   %
	groupName  & /
)  / 0
{!! 	
return"" 
Groups"" 
.""  
RemoveFromGroupAsync"" .
("". /
Context""/ 6
.""6 7
ConnectionId""7 C
,""C D
	groupName""E N
)""N O
;""O P
}## 	
public%% 
async%% 
Task%% 
SendMessageToGroup%% ,
(%%, -
string%%- 3
	groupName%%4 =
,%%= >
string%%? E
message%%F M
)%%M N
{&& 	
await'' 
Clients'' 
.'' 
Group'' 
(''  
	groupName''  )
)'') *
.''* +
	SendAsync''+ 4
(''4 5
$str''5 D
,''D E
message''F M
)''M N
;''N O
}(( 	
})) 
}** ¿
XC:\Users\Max\Documents\GitHub\S3P2_backend\S3P2_project\GroupService\Logic\GroupLogic.cs
	namespace 	
GroupService
 
. 
Logic 
{		 
public

 

class

 

GroupLogic

 
{ 
private 
readonly 

IGroupRepo #
_repo$ )
;) *
private 
readonly 
IMapper  
_mapper! (
;( )
public 

GroupLogic 
( 

IGroupRepo $
repo% )
,) *
IMapper+ 2
mapper3 9
)9 :
{ 	
_repo 
= 
repo 
; 
_mapper 
= 
mapper 
; 
} 	
} 
} ©

OC:\Users\Max\Documents\GitHub\S3P2_backend\S3P2_project\GroupService\Program.cs
	namespace

 	
GroupService


 
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
CreateHostBuilder 
( 
args "
)" #
.# $
Build$ )
() *
)* +
.+ ,
Run, /
(/ 0
)0 1
;1 2
} 	
public 
static 
IHostBuilder "
CreateHostBuilder# 4
(4 5
string5 ;
[; <
]< =
args> B
)B C
=>D F
Host 
.  
CreateDefaultBuilder %
(% &
args& *
)* +
. $
ConfigureWebHostDefaults )
() *

webBuilder* 4
=>5 7
{ 

webBuilder 
. 

UseStartup )
<) *
Startup* 1
>1 2
(2 3
)3 4
;4 5
} 
) 
; 
} 
} Õ
^C:\Users\Max\Documents\GitHub\S3P2_backend\S3P2_project\GroupService\Repositories\GroupRepo.cs
	namespace 	
GroupService
 
. 
Repositories #
{ 
public 

class 
	GroupRepo 
: 

IGroupRepo '
{		 
} 
} ´
_C:\Users\Max\Documents\GitHub\S3P2_backend\S3P2_project\GroupService\Repositories\IGroupRepo.cs
	namespace 	
GroupService
 
. 
Repositories #
{ 
public 

	interface 

IGroupRepo 
{		 
} 
} –!
OC:\Users\Max\Documents\GitHub\S3P2_backend\S3P2_project\GroupService\Startup.cs
	namespace 	
GroupService
 
{ 
public 

class 
Startup 
{ 
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *
} 	
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{   	
services!! 
.!! 
AddControllers!! #
(!!# $
)!!$ %
;!!% &
services"" 
."" 
AddAutoMapper"" "
(""" #
typeof""# )
("") *
Startup""* 1
)""1 2
)""2 3
;""3 4
services$$ 
.$$ 
AddCors$$ 
($$ 
options$$ $
=>$$% '
{%% 
options&& 
.&& 
	AddPolicy&& !
(&&! "
$str&&" 3
,&&3 4
builder&&5 <
=>&&= ?
{'' 
builder(( 
.(( 
AllowAnyOrigin(( *
(((* +
)((+ ,
.((, -
AllowAnyMethod((- ;
(((; <
)((< =
.((= >
AllowAnyHeader((> L
(((L M
)((M N
;((N O
})) 
))) 
;)) 
}** 
)** 
;** 
services,, 
.,, 
AddDbContext,, !
<,,! "
GroupContext,," .
>,,. /
(,,/ 0
options,,0 7
=>,,8 :
{-- 
options.. 
... 
UseSqlServer.. $
(..$ %
Configuration..% 2
...2 3
GetConnectionString..3 F
(..F G
$str..G Y
)..Y Z
)..Z [
;..[ \
}// 
)// 
;// 
services11 
.11 

AddSignalR11 
(11  
options11  '
=>11( *
{22 
options33 
.33  
EnableDetailedErrors33 ,
=33- .
true33/ 3
;333 4
}44 
)44 
;44 
services66 
.66 
	AddScoped66 
<66 

IGroupRepo66 )
,66) *
	GroupRepo66+ 4
>664 5
(665 6
)666 7
;667 8
services77 
.77 
	AddScoped77 
<77 

GroupLogic77 )
>77) *
(77* +
)77+ ,
;77, -
}88 	
public;; 
void;; 
	Configure;; 
(;; 
IApplicationBuilder;; 1
app;;2 5
,;;5 6
IWebHostEnvironment;;7 J
env;;K N
);;N O
{<< 	
if== 
(== 
env== 
.== 
IsDevelopment== !
(==! "
)==" #
)==# $
{>> 
app?? 
.?? %
UseDeveloperExceptionPage?? -
(??- .
)??. /
;??/ 0
}@@ 
appBB 
.BB 
UseHttpsRedirectionBB #
(BB# $
)BB$ %
;BB% &
appDD 
.DD 

UseRoutingDD 
(DD 
)DD 
;DD 
appFF 
.FF 
UseCorsFF 
(FF 
$strFF )
)FF) *
;FF* +
appHH 
.HH 
UseAuthorizationHH  
(HH  !
)HH! "
;HH" #
appJJ 
.JJ 
UseEndpointsJJ 
(JJ 
	endpointsJJ &
=>JJ' )
{KK 
	endpointsLL 
.LL 
MapControllersLL (
(LL( )
)LL) *
;LL* +
	endpointsMM 
.MM 
MapHubMM  
<MM  !
GroupMessagesHubMM! 1
>MM1 2
(MM2 3
$strMM3 >
)MM> ?
;MM? @
}NN 
)NN 
;NN 
}OO 	
}PP 
}QQ Ý
WC:\Users\Max\Documents\GitHub\S3P2_backend\S3P2_project\GroupService\WeatherForecast.cs
	namespace 	
GroupService
 
{ 
public 

class 
WeatherForecast  
{ 
public 
DateTime 
Date 
{ 
get "
;" #
set$ '
;' (
}) *
public		 
int		 
TemperatureC		 
{		  !
get		" %
;		% &
set		' *
;		* +
}		, -
public 
int 
TemperatureF 
=>  "
$num# %
+& '
(( )
int) ,
), -
(- .
TemperatureC. :
/; <
$num= C
)C D
;D E
public 
string 
Summary 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} 