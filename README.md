# Instalações ao iniciar o Workspace do GitPod

link do GitPod: https://www.gitpod.io/

## Instalação do DOTNET

Observação: No Workspace do GitPod, sempre que carregá-lo, terá que instalar o DotNET.

1. Download do arquivo de instalação do DOTNET

```bash
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
```

2. Dar permissão ao arquivo de instalação

```bash
chmod +x dotnet-install.sh
```

3. Instalação do DOTNET a partir do arquivo. `Current` pode ser substituido pelo número da versão.

```bash
./dotnet-install.sh -c Current
```

4. Testando se foi instalado

```bash
dotnet --version
```

5. Se não estiver localizando o caminho do DOTNET, configurar dessa forma:

```bash
echo 'export PATH=$PATH:$HOME/.dotnet' >> ~/.bashrc
source ~/.bashrc
```

## Instalação e configuração do MySQL

Observação: No Workspace do GitPod, sempre que carregá-lo, terá que instalar o MySQL.

1. Instalação

```bash
sudo apt-get install mysql-server
```

Verificar se foi instalado através do comando: `mysql --version`.

2. Iniciar o MySQL Server

```bash
sudo service mysql start
```

3. Acessar o MySQL

```bash
sudo mysql -u root
```

4. Alterar a senha do usuário `root` no MySQL

Conecte-se ao MySQL usando `sudo mysql -u root`.

Execute o seguinte comando para alterar a senha do usuário 'root':

```sql
ALTER USER 'root'@'localhost' IDENTIFIED WITH mysql_native_password BY 'sua_senha';
```

Certifique-se de substituir `'sua_senha'` pela senha desejada.

Após a alteração, você pode tentar acessar o MySQL usando o usuário 'root' e a nova senha.


5. Criar um Usuário MySQL com Senha

Conecte-se ao MySQL usando `sudo mysql -u root`.

Crie um novo usuário com senha e forneça os privilégios necessários:

```sql
CREATE USER 'seu_usuario'@'localhost' IDENTIFIED BY 'sua_senha';
GRANT ALL PRIVILEGES ON *.* TO 'seu_usuario'@'localhost' WITH GRANT OPTION;
FLUSH PRIVILEGES;
```

Certifique-se de substituir `'seu_usuario'` e `'sua_senha'` pelos detalhes desejados.

## Criando um arquivo Shell no Linux para automatizar a instalação do DotNet no Workspace

Se você estiver utilizando o Workspace do GitPod, sempre que carregá-lo, terá que instalar o DotNet.

1. Crie o arquivo `install_dotnet.sh` e adicione o conteúdo abaixo:

```bash
#!/bin/bash

# Baixa o script de instalação do .NET
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh

# Concede permissões de execução ao script
chmod +x dotnet-install.sh

# Executa o script de instalação do .NET, especificando a versão "Current"
./dotnet-install.sh -c Current

# Adiciona o diretório .dotnet ao PATH no arquivo .bashrc
echo 'export PATH=$PATH:$HOME/.dotnet' >> ~/.bashrc

# Atualiza o ambiente atual com as modificações no .bashrc
source ~/.bashrc

# Mensagem indicando a conclusão da instalação
echo ".NET Core instalado com sucesso!"
```

Agora, sempre que precisar instalar o DotNET no Workspace do GitPod, poderá executar esse script.

Após a execução desse script, se você digitar o comando `dotnet --version` e retornar a mensagem que o DotNET não está instalado, execute os comandos abaixo:

```bash
echo 'export PATH=$PATH:$HOME/.dotnet' >> ~/.bashrc
source ~/.bashrc
```

## Criando a aplicação console OlaMundo em C#

1. **Criar um novo projeto:**
   Abra um terminal e navegue até o diretório onde você deseja criar o projeto. Use o seguinte comando para criar um novo projeto console:

   ```bash
   dotnet new console -n OlaMundo
   ```

2. **Navegar para o diretório do projeto:**
   Use o comando `cd` para entrar no diretório do projeto:

   ```bash
   cd OlaMundo
   ```

3. **Editar o código-fonte:**
   Use um editor de texto ou uma IDE de sua escolha para editar o código-fonte. Abra o arquivo `Program.cs` no diretório do projeto e faça as alterações necessárias.

   ```csharp
   using System;

   class Program
   {
       static void Main()
       {
           Console.WriteLine("Olá, Mundo!");
       }
   }
   ```

4. **Compilar e Executar:**
   No terminal, execute o seguinte comando para compilar e executar o projeto:

   ```bash
   dotnet run
   ```

   Isso irá compilar o código e executar a aplicação console, exibindo a mensagem "Olá, Mundo!".

## Criando a aplicação console CaixaRegistradora em C#

1. **Criar um novo projeto:**
   Abra um terminal e navegue até o diretório onde você deseja criar o projeto. Use o seguinte comando para criar um novo projeto console:

   ```bash
   dotnet new console -n CaixaRegistradora
   ```

2. **Navegar para o diretório do projeto:**
   Use o comando `cd` para entrar no diretório do projeto:

   ```bash
   cd CaixaRegistradora
   ```

3. **Editar o código-fonte:**
   Use um editor de texto ou uma IDE de sua escolha para editar o código-fonte. Abra o arquivo `Program.cs` no diretório do projeto e faça as alterações necessárias.

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Clear(); // Limpa a tela no início da execução

        Console.WriteLine("Bem-vindo ao Sistema de Venda de Produtos"); // Exibe o nome da aplicação
        Console.WriteLine(new string('-', 40)); // Linha de caracteres '-' repetidos 40 vezes

        int opcao;
        do
        {
            ExibirMenu();
            opcao = LerOpcao();

            switch (opcao)
            {
                case 1:
                    // Opção para "Registrar Venda"
                    Console.Clear();
                    Console.WriteLine("Opção selecionada: Registrar Venda");
                    RegistrarVenda();
                    break;
                case 2:
                    // Opção para "Sair"
                    Console.WriteLine("Obrigado por utilizar o Sistema de Venda de Produtos!");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        } while (opcao != 2);
    }

    static void ExibirMenu()
    {
        Console.WriteLine("MENU:");
        Console.WriteLine("1. Registrar Venda");
        Console.WriteLine("2. Sair");
        Console.Write("Escolha a opção desejada: ");
    }

    static int LerOpcao()
    {
        return Convert.ToInt32(Console.ReadLine());
    }

    static void RegistrarVenda()
    {
        List<Produto> listaProdutos = new List<Produto>();

        do
        {
            AdicionarProduto(listaProdutos);
        } while (DesejaInserirOutroProduto());

        ExibirRecibo(listaProdutos);

        Console.WriteLine("Digite o valor pago:");
        double valorPago = Convert.ToDouble(Console.ReadLine());

        CalcularTroco(listaProdutos, valorPago);

        Console.WriteLine("Pressione Enter para voltar ao menu...");
        Console.ReadLine(); // Aguarda o Enter antes de voltar ao menu
    }

    static void AdicionarProduto(List<Produto> listaProdutos)
    {
        Console.WriteLine("Digite o nome do produto:");
        string nomeProduto = Console.ReadLine();

        Console.WriteLine("Digite a quantidade:");
        int quantidade = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Digite o valor unitário:");
        double valorUnitario = Convert.ToDouble(Console.ReadLine());

        Produto produto = new Produto(nomeProduto, quantidade, valorUnitario);
        listaProdutos.Add(produto);
    }

    static bool DesejaInserirOutroProduto()
    {
        Console.WriteLine("Deseja inserir outro produto? (S/N)");
        string resposta = Console.ReadLine().ToUpper();
        return resposta == "S";
    }

    static void ExibirRecibo(List<Produto> listaProdutos)
    {
        Console.WriteLine("Lista de Produtos:");
        Console.WriteLine("------------------");

        double totalPagar = 0;

        foreach (var produto in listaProdutos)
        {
            Console.WriteLine($"{produto.Nome} - Quantidade: {produto.Quantidade} - Valor Unitário: {produto.ValorUnitario:C} - Subtotal: {produto.Subtotal:C}");
            totalPagar += produto.Subtotal;
        }

        Console.WriteLine("------------------");
        Console.WriteLine($"Total a Pagar: {totalPagar:C}");
        Console.WriteLine();
    }

    static void CalcularTroco(List<Produto> listaProdutos, double valorPago)
    {
        double totalPagar = 0;

        foreach (var produto in listaProdutos)
        {
            totalPagar += produto.Subtotal;
        }

        if (valorPago < totalPagar)
        {
            Console.WriteLine($"Valor insuficiente! Faltam: {(totalPagar - valorPago):C}");
        }
        else
        {
            double troco = valorPago - totalPagar;
            Console.WriteLine($"Troco a devolver: {troco:C}");
        }
    }
}

class Produto
{
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public double ValorUnitario { get; set; }

    public Produto(string nome, int quantidade, double valorUnitario)
    {
        Nome = nome;
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;
    }

    public double Subtotal
    {
        get { return Quantidade * ValorUnitario; }
    }
}
```

4. **Compilar e Executar:**
   No terminal, execute o seguinte comando para compilar e executar o projeto:

   ```bash
   dotnet run
   ```

   Isso irá compilar o código e executar a aplicação console, o Menu Incial.

## Compilando e criando um arquivo executável da aplicação C#

### Criando o Executal Linux

Se você deseja criar um executável específico para o Linux, você pode fazer isso usando o comando `dotnet publish` com a opção `-r linux-x64`. Este comando compila e publica seu projeto para a arquitetura x64 do Linux. Aqui estão os passos:

1. **Navegue até o diretório do projeto:**
   No terminal, vá para o diretório do seu projeto:

   ```bash
   cd Caminho/Para/Seu/Projeto
   ```

2. **Compilar e publicar para Linux:**
   Use o comando `dotnet publish` para compilar e publicar o projeto para Linux. Certifique-se de especificar a arquitetura correta (`linux-x64`):

   ```bash
   dotnet publish -c Release -r linux-x64
   ```

   Isso cria os arquivos necessários na pasta `bin/Release/netcoreappX.X/linux-x64/publish/`.

3. **Navegue até a pasta de publicação:**
   Vá para o diretório de publicação do projeto:

   ```bash
   cd bin/Release/netcoreappX.X/linux-x64/publish/
   ```

4. **Execute o executável:**
   Execute o executável da sua aplicação:

   ```bash
   ./NomeDoProjeto
   ```

   Substitua `NomeDoProjeto` pelo nome do seu executável.

Esses passos garantirão que você tenha um executável específico para Linux. Lembre-se de que, ao usar a opção `-r linux-x64`, você está especificando a arquitetura alvo como x64. Se você estiver implantando em sistemas Linux com uma arquitetura diferente, ajuste a opção `-r` conforme necessário (por exemplo, `linux-arm` para arquitetura ARM).

### Criando o Executal Windows

Para criar um executável específico para Windows, você pode usar o comando `dotnet publish` com a opção `-r win-x64` para compilar e publicar o seu projeto para a arquitetura x64 do Windows. Aqui estão os passos:

1. **Navegue até o diretório do projeto:**
   No terminal, vá para o diretório do seu projeto:

   ```bash
   cd Caminho/Para/Seu/Projeto
   ```

2. **Compilar e publicar para Windows:**
   Use o comando `dotnet publish` para compilar e publicar o projeto para Windows. Certifique-se de especificar a arquitetura correta (`win-x64`):

   ```bash
   dotnet publish -c Release -r win-x64
   ```

   Isso cria os arquivos necessários na pasta `bin/Release/netcoreappX.X/win-x64/publish/`.

3. **Navegue até a pasta de publicação:**
   Vá para o diretório de publicação do projeto:

   ```bash
   cd bin/Release/netcoreappX.X/win-x64/publish/
   ```

4. **Execute o executável:**
   Execute o executável da sua aplicação:

   ```bash
   NomeDoProjeto.exe
   ```

   Substitua `NomeDoProjeto` pelo nome do seu executável. Note que em sistemas Windows, a extensão do executável é `.exe`.

Esses passos garantirão que você tenha um executável específico para Windows. Se estiver implantando em sistemas Windows com uma arquitetura diferente, ajuste a opção `-r` conforme necessário (por exemplo, `win-x86` para arquitetura x86, ou 32bit).