import React, { createContext, useState, useEffect, ReactNode } from 'react';
import api from '../services/api';

type Cidade = {
  codigo: number;
  nome: string;
  codigoDoEstado: number;
  precoPadrao: number;
};

type CidadeContextType = {
  cidades: Cidade[];
  fetchCidades: () => void;
  addCidade: (cidade: Cidade) => Promise<void>; // Inclui o campo 'codigo'
  updateCidade: (codigo: number, cidade: Partial<Cidade>) => Promise<void>;
  deleteCidade: (codigo: number) => Promise<void>;
};

export const CidadeContext = createContext<CidadeContextType | undefined>(undefined);

export const CidadeProvider = ({ children }: { children: ReactNode }) => {
  const [cidades, setCidades] = useState<Cidade[]>([]);

  const fetchCidades = async () => {
    try {
      const response = await api.get('/api/Home/ObterCidades'); // Ajuste a rota conforme o seu backend
      setCidades(response.data);
    } catch (error) {
      console.error('Erro ao buscar cidades:', error);
    }
  };

  const addCidade = async (cidade: Cidade) => { // Inclui 'codigo'
    try {
      await api.post('/api/Home/AdicionarCidade', cidade);
      fetchCidades();
    } catch (error) {
      console.error('Erro ao adicionar cidade:', error);
    }
  };

  const updateCidade = async (codigo: number, cidade: Partial<Cidade>) => {
    try {
      const payload = { ...cidade, codigo }; // Inclui 'codigo' no payload
      console.log('Payload enviado para atualização:', payload); // Debug
      await api.put(`/api/Home/AtualizarCidade/${codigo}`, payload);
      fetchCidades(); // Atualiza a lista de cidades
    } catch (error) {
      console.error('Erro ao atualizar cidade:', error);
    }
  };

  const deleteCidade = async (codigo: number) => {
    try {
      await api.delete(`/api/Home/DeletarCidade/${codigo}`);
      fetchCidades();
    } catch (error) {
      console.error('Erro ao deletar cidade:', error);
    }
  };

  useEffect(() => {
    fetchCidades();
  }, []);

  return (
    <CidadeContext.Provider value={{ cidades, fetchCidades, addCidade, updateCidade, deleteCidade }}>
      {children}
    </CidadeContext.Provider>
  );
};
