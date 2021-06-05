# Documentation

## [/casher](casherMS/CasherController.cs)
### GET /casher/alive
Body:
```
    Empty
```
- Response 200 -> alive
- Response ANY -> dead

### POST /casher/deposit?account_id={id}&amount={amount}
Body:
```
    Empty
```
- Response 200 
```json
    {
       "status" : bool 
    }
```

### GET /casher/withdraw?account_id={id}&amount={amount}
Body:
```
    Empty
```
- Response 200 
```json
    {
       "status" : bool 
    }
```

### GET /casher/getCashFlows?user_id={id}
Body:
```
    Empty
```
- Response 200 
```json
    {
        "responce" : [
            {
                "id ": int,
                "userId" : int,
                "name" : string,
                "amount" : long,
                "frozen" : long,
            },
            {
                "id ": int,
                "userId" : int,
                "name" : string,
                "amount" : long,
                "frozen" : long,
            },
        ]
    }
```

### GET /casher/getCashFlow?account_id={id}
Body:
```
    Empty
```
- Response 200 
```json
    {
        "id ": int,
        "userId" : int,
        "name" : string,
        "amount" : long,
        "frozen" : long,
    }
```

## [/documents](documentsMS/DocumentsController.cs)
### GET /documents/alive
Body:
```
    Empty
```
- Response 200 -> alive
- Response ANY -> dead
### GET /documents/doc?id={id}
Body:
```
    Empty
```
- Response 200
```json
    {
        "id" : int,
        "type" : int,
        "name" : string,
        "data" : stringBase64
    }
```

## [/logging](documentsMS/loggingMS/LoggingController.cs)
### GET /logging/alive
Body:
```
    Empty
```
- Response 200 -> alive
- Response ANY -> dead
### GET /logging/log
Body:
```json
    {
        "log" : string
    }
```
- Response 200 -> alive

## [/monitoring](monitoringMS/MonitoringController.cs)
### GET /monitoring/alive
Body:
```
    Empty
```
- Response 200
- Response ANY -> dead
### GET /monitoring/status
Body:
```
    Empty
```
- Response 200
```json
    {
        "seviceName0" : "status",
        "seviceName1" : "status",
    }
```

## [/operations](operationsMS/OperationsController.cs)
### GET /operations/alive
Body:
```
    Empty
```
- Response 200 -> alive
- Response ANY -> dead
### GET /operations/operationHistory?id={id}&historyCount={count}
Body:
```
    Empty
```
- Response 200
```json
    {
        "response" : [
            {
                "id" : int,
                "type" : int,
                "status" : int,
                "meta" : {
                    "param0" : type,
                    "param1" : type,
                    "paramN" : type,
                }
            },
        ]
    }
```
### DELETE /operations/operationHistory?id={id}&historyCount={count}
Body:
```
    Empty
```
- Response 200
```json
    {
        "canceled" : int
    }
```
### GET /operations/operation?type={type}
Body:
```
    Empty
```
- Response 200
```json
    {
        "id" : int,
        "type" : int,
        "response" : {
            "param0" : type,
            "param1" : type,
            "paramN" : type,
        }
    }
```



### POST /operations/operation
Body:
```json
    {
        "id" : int,
        "type" : int,
        "response" : {
            "param0" : "value",
            "param1" : 0,
            "paramN" : "value",
        },
        "end_flag" : true or false
    }
```
- Response 200
```json
    {
        "id" : int,
        "type" : int,
        "response" : {
            "param0" : "type",
            "param1" : "type",
            "paramN" : "type",
        },
        "end_flag" : true or false
    }
```

## [/statistics](statisticsMS/StatisticsController.cs)
### GET /statistics/alive
Body:
```
    Empty
```
- Response 200 -> alive
- Response ANY -> dead

## [/users](usersMS/UsersController.cs)
### GET /users/alive
Body:
```
    Empty
```
- Response 200 -> alive
- Response ANY -> dead
### GET /users/get?id={userId}
Body
```
    Empty
```
- Response 200
```json
{
    // -1 - no priveleges
    // 0 - common user
    // 1 - manager who can aprove
    // 2 - manager who can aprove, modify, delete
    // 3 - admin
    "id" :  int , 
    "priv" :  int, 
    "name" : string 
}
```
### GET /users/getSome?from={from}&count={count}
Body
```
    Empty
```
- Response 200
```json
{
    "response" : [
        {
            "id" :  int , 
            "priv" :  int, 
            "name" : string 
        },
    ]
}
```