# Instalações ao iniciar o Workspace do GitPod

## Instalação do DOTNET

1. Download do arquivo de instalação do DOTNET

```bash
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
```

2. Dar permissão ao arquivo de instalação

```bash
chmod +x dotnet-install.sh`
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

Se você precisa executar `sudo mysql -u root` para acessar o MySQL, pode ser um indicativo de que o usuário 'root' está configurado para autenticação usando o plugin 'auth_socket' em vez de senha.

O plugin 'auth_socket' permite autenticação do usuário do MySQL com base nas credenciais do sistema operacional. Portanto, se você estiver tentando acessar o MySQL sem senha usando o usuário 'root' e precisar de privilégios administrativos, você pode precisar ajustar as configurações.

Aqui estão algumas opções que você pode considerar:

**Observação: A principio, executar apenas os passos 1 e 2.**

1. **Criar um Usuário MySQL com Senha:**
   - Conecte-se ao MySQL usando `sudo mysql -u root`.
   - Crie um novo usuário com senha e forneça os privilégios necessários:

     ```sql
     CREATE USER 'seu_usuario'@'localhost' IDENTIFIED BY 'sua_senha';
     GRANT ALL PRIVILEGES ON *.* TO 'seu_usuario'@'localhost' WITH GRANT OPTION;
     FLUSH PRIVILEGES;
     ```

   Certifique-se de substituir `'seu_usuario'` e `'sua_senha'` pelos detalhes desejados.

2. **Modificar o Usuário 'root' para Autenticação por Senha:**
   - Conecte-se ao MySQL usando `sudo mysql -u root`.
   - Execute o seguinte comando para alterar a senha do usuário 'root':

     ```sql
     ALTER USER 'root'@'localhost' IDENTIFIED WITH mysql_native_password BY 'sua_senha';
     ```

   Certifique-se de substituir `'sua_senha'` pela senha desejada.

   - Após a alteração, você pode tentar acessar o MySQL usando o usuário 'root' e a nova senha.

3. **Atualizar Configurações no Arquivo my.cnf:**
   - Abra o arquivo de configuração do MySQL (`/etc/mysql/my.cnf` ou `/etc/my.cnf`).
   - Adicione ou modifique a seção `[mysqld]` para incluir a linha:

     ```ini
     plugin-load-add = auth_socket.so
     ```

     para:

     ```ini
     plugin-load-add = auth_socket.so mysql_native_password.so
     ```

   - Reinicie o serviço MySQL:

     ```bash
     sudo service mysql restart
     ```

   Certifique-se de ter um backup do arquivo de configuração antes de fazer alterações.

Depois de realizar uma dessas opções, você deve ser capaz de conectar-se ao MySQL usando o usuário e a senha especificados no seu aplicativo. Certifique-se de ajustar as configurações do seu aplicativo para refletir as alterações.