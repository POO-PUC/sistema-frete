import React, { createContext, useState, useEffect, ReactNode } from 'react';
import api from '../services/api';

type PessoaJuridica = {
  codigo: number;
  razaoSocial: string;
  inscricaoEstadual: string;
  cnpj: string;
  ehRepresentante: boolean;
};

type PessoaJuridicaContextType = {
  pessoasJuridicas: PessoaJuridica[];
  fetchPessoasJuridicas: () => void;
  addPessoaJuridica: (pessoaJuridica: PessoaJuridica) => Promise<void>;
  updatePessoaJuridica: (codigo: number, pessoaJuridica: Partial<PessoaJuridica>) => Promise<void>;
  deletePessoaJuridica: (codigo: number) => Promise<void>;
};

export const PessoaJuridicaContext = createContext<PessoaJuridicaContextType | undefined>(undefined);

export const PessoaJuridicaProvider = ({ children }: { children: ReactNode }) => {
  const [pessoasJuridicas, setPessoasJuridicas] = useState<PessoaJuridica[]>([]);

  const fetchPessoasJuridicas = async () => {
    try {
      const response = await api.get('/api/Home/ObterPessoasJuridicas');
      setPessoasJuridicas(response.data);
    } catch (error) {
      console.error('Erro ao buscar pessoas jurídicas:', error);
    }
  };

  const addPessoaJuridica = async (pessoaJuridica: PessoaJuridica) => {
    try {
      await api.post('/api/Home/AdicionarPessoaJuridica', pessoaJuridica);
      fetchPessoasJuridicas();
    } catch (error) {
      console.error('Erro ao adicionar pessoa jurídica:', error);
    }
  };

  const updatePessoaJuridica = async (codigo: number, pessoaJuridica: Partial<PessoaJuridica>) => {
    try {
      const payload = { ...pessoaJuridica, codigo };
      console.log('Payload enviado para atualização:', payload);
      await api.put(`/api/Home/AtualizarPessoaJuridica/${codigo}`, payload);
      fetchPessoasJuridicas();
    } catch (error) {
      console.error('Erro ao atualizar pessoa jurídica:', error);
    }
  };

  const deletePessoaJuridica = async (codigo: number) => {
    try {
      await api.delete(`/api/Home/DeletarPessoaJuridica/${codigo}`);
      fetchPessoasJuridicas();
    } catch (error) {
      console.error('Erro ao deletar pessoa jurídica:', error);
    }
  };

  useEffect(() => {
    fetchPessoasJuridicas();
  }, []);

  return (
    <PessoaJuridicaContext.Provider
      value={{
        pessoasJuridicas,
        fetchPessoasJuridicas,
        addPessoaJuridica,
        updatePessoaJuridica,
        deletePessoaJuridica,
      }}
    >
      {children}
    </PessoaJuridicaContext.Provider>
  );
};
