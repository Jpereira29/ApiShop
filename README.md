# ApiShop

<p>Este projeto foi feito com intuito de desempenhar e melhorar minhas habilidades no desenvolvimento backend utilizando a linguagem C# na plataforma .NET.</p>
<hr />
<h3>Foram utilizadas as seguintes tecnologias:</h3>
<ul>
  <li>C#</li>
  <li>.NET</li>
  <li>Entity Framework Core</li>
  <li>MySql</li>
</ul>

<p>Este projeto consiste em uma API feita nos padrões RESTFull, seguindo o modelo de uma loja virtual.</p>

<h3>O projeto tem os seguintes modelos:</h3>
<ul>
  <li>Categoria</li>
  <li>Produto</li>
  <li>Vendedor</li>
</ul>

<p>Possui um controlador para cada categoria e cada controlador possui um serviço para manipular o banco de dados, a manipulação é feita utilizando o Entity Framework Core.</p>

<hr />
<h4>O projeto foi documentado com o Swagger, por isso, nada te impede de testá-lo 😉.</h4>
<img src="https://user-images.githubusercontent.com/105259665/203850089-8f05674a-d9ec-4b4e-8ede-78ac0faa8f80.png" />
<br />

### Pré requisitos
<p>Tenha o <a href="https://dev.mysql.com/downloads/workbench/">MySql</a> instalado em seu pc</p>
installe o <a href="https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.403-windows-x64-installer">.NET SDK</a> para seu sistema operacional

### Rodando a aplicação

### Clone o repositório
```bash
git clone https://github.com/Jpereira29/ApiShop.git
```

### Entre na pasta do projeto
```bash
cd .\ApiShop\ApiShop
```
### Antes de rodar a aplicação faça a seguite alteração
altere o usuário e senha da string de conexão para seu usuário:
```bash
[arquivo appsettings.json]
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;DataBase=ShopDB;Uid=root;Pwd=root"
  },
```

### populando as tabelas
```bash
dotnet ef database update
```

### Rode o projeto
```bash
dotnet run dev
```
<a>https://localhost:7155/swagger/index.html</a>


<p>O projeto ainda encontra-se na fase de desenvolvimento, atualizações posteriores incluirão autenticação e frontend a parte para consumo da API.</p>
