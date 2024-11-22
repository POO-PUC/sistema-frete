import React, { createContext, useState, useEffect, ReactNode } from 'react';
import api from '../services/api';

type PessoaFisica = {
  codigo: number;
  nome: string;
  cpf: string;
  codigoDoRepresentante: number | null; // Representante opcional
};

type PessoaFisicaContextType = {
  pessoasFisicas: PessoaFisica[];
  fetchPessoasFisicas: () => void;
  addPessoaFisica: (pessoaFisica: PessoaFisica) => Promise<void>;
  updatePessoaFisica: (codigo: number, pessoaFisica: Partial<PessoaFisica>) => Promise<void>;
  deletePessoaFisica: (codigo: number) => Promise<void>;
};

export const PessoaFisicaContext = createContext<PessoaFisicaContextType | undefined>(undefined);

export const PessoaFisicaProvider = ({ children }: { children: ReactNode }) => {
  const [pessoasFisicas, setPessoasFisicas] = useState<PessoaFisica[]>([]);

  const fetchPessoasFisicas = async () => {
    try {
      const response = await api.get('/api/Home/ObterPessoasFisicas');
      setPessoasFisicas(response.data);
    } catch (error) {
      console.error('Erro ao buscar pessoas físicas:', error);
    }
  };

  const addPessoaFisica = async (pessoaFisica: PessoaFisica) => {
    try {
      await api.post('/api/Home/AdicionarPessoaFisica', pessoaFisica);
      fetchPessoasFisicas();
    } catch (error) {
      console.error('Erro ao adicionar pessoa física:', error);
    }
  };

  const updatePessoaFisica = async (codigo: number, pessoaFisica: Partial<PessoaFisica>) => {
    try {
      const payload = { ...pessoaFisica, codigo };
      console.log('Payload enviado para atualização:', payload); // Debug para verificar os dados enviados
      await api.put(`/api/Home/AtualizarPessoaFisica/${codigo}`, payload);
      fetchPessoasFisicas();
    } catch (error) {
      console.error('Erro ao atualizar pessoa física:', error);
    }
  };

  const deletePessoaFisica = async (codigo: number) => {
    try {
      await api.delete(`/api/Home/DeletarPessoaFisica/${codigo}`);
      fetchPessoasFisicas();
    } catch (error) {
      console.error('Erro ao deletar pessoa física:', error);
    }
  };

  useEffect(() => {
    fetchPessoasFisicas();
  }, []);

  return (
    <PessoaFisicaContext.Provider
      value={{
        pessoasFisicas,
        fetchPessoasFisicas,
        addPessoaFisica,
        updatePessoaFisica,
        deletePessoaFisica,
      }}
    >
      {children}
    </PessoaFisicaContext.Provider>
  );
};
