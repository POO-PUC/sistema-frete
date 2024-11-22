import React, { createContext, useState, useEffect, ReactNode } from 'react';
import api from '../services/api';

type Frete = {
  codigo: number;
  peso: number;
  valor: number;
  icms: number;
  pedagio: number;
  dataInicio: string;
  codigoDaCidadeDeOrigem: number;
  codigoDaCidadeDeDestino: number;
  codigoDoCliente: number;
  codigoDoDestinatario: number;
  codigoDoFuncionario: number;
  quemPaga: string;
  numeroDeConhecimento: string;
};

type FreteContextType = {
  fretes: Frete[];
  fetchFretes: () => void;
  addFrete: (frete: Frete) => Promise<void>;
  updateFrete: (codigo: number, frete: Partial<Frete>) => Promise<void>;
  deleteFrete: (codigo: number) => Promise<void>;
};

export const FreteContext = createContext<FreteContextType | undefined>(undefined);

export const FreteProvider = ({ children }: { children: ReactNode }) => {
  const [fretes, setFretes] = useState<Frete[]>([]);

  const fetchFretes = async () => {
    try {
      const response = await api.get('/api/Home/ObterFretes');
      setFretes(response.data);
    } catch (error) {
      console.error('Erro ao buscar fretes:', error);
    }
  };

  const addFrete = async (frete: Frete) => {
    try {
      await api.post('/api/Home/AdicionarFrete', frete);
      fetchFretes();
    } catch (error) {
      console.error('Erro ao adicionar frete:', error);
    }
  };

  const updateFrete = async (codigo: number, frete: Partial<Frete>) => {
    try {
      await api.put(`/api/Home/AtualizarFrete/${codigo}`, frete);
      fetchFretes();
    } catch (error) {
      console.error('Erro ao atualizar frete:', error);
    }
  };

  const deleteFrete = async (codigo: number) => {
    try {
      await api.delete(`/api/Home/DeletarFrete/${codigo}`);
      fetchFretes();
    } catch (error) {
      console.error('Erro ao deletar frete:', error);
    }
  };

  useEffect(() => {
    fetchFretes();
  }, []);

  return (
    <FreteContext.Provider value={{ fretes, fetchFretes, addFrete, updateFrete, deleteFrete }}>
      {children}
    </FreteContext.Provider>
  );
};
