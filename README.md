# projectschool

## Project setup
```
npm install
```

### Install JSON Server
```
npm install -g json-server
```

### Create a db.json file with some data
```
{
  "posts": [
    { "id": 1, "title": "json-server", "author": "typicode" }
  ],
  "comments": [
    { "id": 1, "body": "some comment", "postId": 1 }
  ],
  "profile": { "name": "typicode" }
}
```

### Run fake API
```
json-server --watch banco.json
```

### If the First run, exec commando to creat node_modules
```
npm i
```

### Compiles and hot-reloads for development
```
npm run serve
```

### If you need to access Ui interface
```
vue ui
```

### Compiles and minifies for production
```
npm run build
```

### Run your tests
```
npm run test
```

### Lints and fixes files
```
npm run lint
```


## Problemas com o Git (Erro ao executar Pull)
```
git pull / git pull origin master
```
## Necessário rodar
```
git clean  -d  -fx . / git clean  -d  -f .
```

### Customize configuration
See [Configuration Reference](https://cli.vuejs.org/config/).
