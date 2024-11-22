import React, { createContext, useState, useEffect, ReactNode } from 'react';
import api from '../services/api';

type Estado = {
  codigo: number; 
  nome: string;   
  uf: string;
  icmsLocal: number;    
  icmsExterno: number;  
};

type EstadoContextType = {
  estados: Estado[];
  fetchEstados: () => void;
  addEstado: (estado: Estado) => Promise<void>; // Inclui o campo 'codigo'
  updateEstado: (id: number, estado: Partial<Estado>) => Promise<void>;
  deleteEstado: (id: number) => Promise<void>;
};

export const EstadoContext = createContext<EstadoContextType | undefined>(undefined);

export const EstadoProvider = ({ children }: { children: ReactNode }) => {
  const [estados, setEstados] = useState<Estado[]>([]);

  const fetchEstados = async () => {
    try {
      const response = await api.get('/api/Home/ObterEstados');
      setEstados(response.data);
    } catch (error) {
      console.error('Erro ao buscar estados:', error);
    }
  };

  const addEstado = async (estado: Estado) => { // Inclui 'codigo'
    try {
      await api.post('/api/Home/AdicionarEstado', estado);
      fetchEstados();
    } catch (error) {
      console.error('Erro ao adicionar estado:', error);
    }
  };

  const updateEstado = async (id: number, estado: Partial<Estado>) => {
    try {
      const payload = { ...estado, codigo: id }; // Inclui 'codigo' no payload
      console.log("Payload enviado para atualização:", payload); // Debug
      await api.put(`/api/Home/AtualizarEstado/${id}`, payload);
      fetchEstados();
    } catch (error) {
      console.error('Erro ao atualizar estado:', error);
    }
  };

  const deleteEstado = async (id: number) => {
    try {
      await api.delete(`/api/Home/DeletarEstado/${id}`);
      fetchEstados();
    } catch (error) {
      console.error('Erro ao deletar estado:', error);
    }
  };

  useEffect(() => {
    fetchEstados();
  }, []);

  return (
    <EstadoContext.Provider value={{ estados, fetchEstados, addEstado, updateEstado, deleteEstado }}>
      {children}
    </EstadoContext.Provider>
  );
};
