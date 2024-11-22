import React, { createContext, useState, useEffect, ReactNode } from 'react';
import api from '../services/api';

type Funcionario = {
  codigo: number;
  nome: string;
  numeroDeRegistro: number;
};

type FuncionarioContextType = {
  funcionarios: Funcionario[];
  fetchFuncionarios: () => void;
  addFuncionario: (funcionario: Funcionario) => Promise<void>;
  updateFuncionario: (codigo: number, funcionario: Partial<Funcionario>) => Promise<void>;
  deleteFuncionario: (codigo: number) => Promise<void>;
};

export const FuncionarioContext = createContext<FuncionarioContextType | undefined>(undefined);

export const FuncionarioProvider = ({ children }: { children: ReactNode }) => {
  const [funcionarios, setFuncionarios] = useState<Funcionario[]>([]);

  const fetchFuncionarios = async () => {
    try {
      const response = await api.get('/api/Home/ObterFuncionarios');
      setFuncionarios(response.data);
    } catch (error) {
      console.error('Erro ao buscar funcionários:', error);
    }
  };

  const addFuncionario = async (funcionario: Funcionario) => {
    try {
      await api.post('/api/Home/AdicionarFuncionario', funcionario);
      fetchFuncionarios();
    } catch (error) {
      console.error('Erro ao adicionar funcionário:', error);
    }
  };

  const updateFuncionario = async (codigo: number, funcionario: Partial<Funcionario>) => {
    try {
      const payload = { ...funcionario, codigo };
      console.log('Payload enviado para atualização:', payload);
      await api.put(`/api/Home/AtualizarFuncionario/${codigo}`, payload);
      fetchFuncionarios();
    } catch (error) {
      console.error('Erro ao atualizar funcionário:', error);
    }
  };

  const deleteFuncionario = async (codigo: number) => {
    try {
      await api.delete(`/api/Home/DeletarFuncionario/${codigo}`);
      fetchFuncionarios();
    } catch (error) {
      console.error('Erro ao deletar funcionário:', error);
    }
  };

  useEffect(() => {
    fetchFuncionarios();
  }, []);

  return (
    <FuncionarioContext.Provider
      value={{ funcionarios, fetchFuncionarios, addFuncionario, updateFuncionario, deleteFuncionario }}
    >
      {children}
    </FuncionarioContext.Provider>
  );
};
