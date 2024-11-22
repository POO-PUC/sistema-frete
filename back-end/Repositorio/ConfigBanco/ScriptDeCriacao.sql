-- Criação da tabela Estado (PAI)
CREATE TABLE Estado (
    id_estado INT PRIMARY KEY,
    nome_estado VARCHAR(100),
    uf VARCHAR(2),
    icms_local DECIMAL(10, 2),
    icms_outro_uf DECIMAL(10, 2)
);

-- Criação da tabela Cliente (PAI)
CREATE TABLE Cliente (
    cod_cliente INT PRIMARY KEY,
    endereco VARCHAR(255),
    telefone VARCHAR(20),
    data_inscricao DATE
);

-- Criação da tabela Cidade (PAI) que depende da tabela Estado
CREATE TABLE Cidade (
    id_cidade INT PRIMARY KEY,
    nome_cidade VARCHAR(100),
    id_estado INT,
    valor DECIMAL(10, 2),
    FOREIGN KEY (id_estado) REFERENCES Estado(id_estado)
);

-- Criação da tabela de Funcionário (PAI)
CREATE TABLE Funcionario (
    id_funcionario INT PRIMARY KEY,
    nome_funcionario VARCHAR(100),
    num_registro INT
);

-- Criação da tabela Pessoa Jurídica (FILHO) que depende de Cliente
CREATE TABLE PessoaJuridica (
    cod_PessoaJuridica INT PRIMARY KEY,
    razao_social VARCHAR(100),
    inscricao_estadual VARCHAR(20),
    cnpj VARCHAR(20),
    eh_representante BOOLEAN,
    FOREIGN KEY (cod_PessoaJuridica) REFERENCES Cliente(cod_cliente)
);

-- Criação da tabela Pessoa Física (FILHO) que depende de Cliente
CREATE TABLE PessoaFisica (
    cod_PessoaFisica INT PRIMARY KEY,
    nome_cliente VARCHAR(100),
    cpf VARCHAR(14),
    representante INT NULL,
    FOREIGN KEY (cod_PessoaFisica) REFERENCES Cliente(cod_cliente),
    FOREIGN KEY (representante) REFERENCES PessoaJuridica(cod_PessoaJuridica)
);

-- Criação da tabela Frete (FILHO) que depende de Cidade, Cliente e Funcionário
CREATE TABLE Frete (
    id_frete INT PRIMARY KEY,
    peso DECIMAL(10, 2),
    valor DECIMAL(10, 2),
    icms DECIMAL(10, 2),
    pedagio DECIMAL(10, 2),
    data_frete DATE,
    id_origem INT,
    id_destino INT,
    id_remetente INT,
    id_destinatario INT,
    id_funcionario INT,
    quem_paga VARCHAR(20),
    num_conhecimento VARCHAR(50),
    FOREIGN KEY (id_origem) REFERENCES Cidade(id_cidade),
    FOREIGN KEY (id_destino) REFERENCES Cidade(id_cidade),
    FOREIGN KEY (id_remetente) REFERENCES Cliente(cod_cliente),
    FOREIGN KEY (id_destinatario) REFERENCES Cliente(cod_cliente),
    FOREIGN KEY (id_funcionario) REFERENCES Funcionario(id_funcionario)
);

