# CREATE DATABASE db_clientlab;
USE db_clientlab;
CREATE TABLE tb_cliente_pf (
	id_cliente INT AUTO_INCREMENT PRIMARY KEY,
    nm_cliente VARCHAR(100) NOT NULL,
    ed_cliente VARCHAR(255) NOT NULL,
    cpf_cliente VARCHAR(30) NOT NULL,
    rg_cliente VARCHAR(30) NOT NULL
);

CREATE TABLE tb_cliente_pj (
	id_cliente INT AUTO_INCREMENT PRIMARY KEY,
    nm_cliente VARCHAR(100) NOT NULL,
    ed_cliente VARCHAR(100) NOT NULL,
    cnpj_cliente VARCHAR(30) NOT NULL,
    ie_cliente VARCHAR(30) NOT NULL
);

CREATE TABLE tb_vendas (
	id_venda INT AUTO_INCREMENT PRIMARY KEY,
    data_hora_venda DATETIME DEFAULT CURRENT_TIMESTAMP,
    vl_compra DECIMAL (10,2) NOT NULL,
    vl_imposto DECIMAL (10,2) NOT NULL,
    vl_total DECIMAL (10,2) NOT NULL,
    fk_cliente_pf INT,
    fk_cliente_pj INT,
    FOREIGN KEY (fk_cliente_pf) REFERENCES tb_cliente_pf(id_cliente),
    FOREIGN KEY (fk_cliente_pj) REFERENCES tb_cliente_pj(id_cliente)
);


