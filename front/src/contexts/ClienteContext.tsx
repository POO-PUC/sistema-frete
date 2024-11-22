import React, { createContext, useState, useEffect, ReactNode, useCallback } from 'react';
import api from '../services/api';
import { toast } from 'react-toastify';

type Cliente = {
  codigo: number;
  endereco: string;
  telefone: string;
  dataDeInscricao: string;
};

type ClienteContextType = {
  clientes: Cliente[];
  fetchClientes: () => void;
  addCliente: (cliente: Cliente) => Promise<void>;
  updateCliente: (codigo: number, cliente: Partial<Cliente>) => Promise<void>;
  deleteCliente: (codigo: number) => Promise<void>;
};

export const ClienteContext = createContext<ClienteContextType | undefined>(undefined);

export const ClienteProvider = ({ children }: { children: ReactNode }) => {
  const [clientes, setClientes] = useState<Cliente[]>([]);

  // Memoize the fetch function
  const fetchClientes = useCallback(async () => {
    try {
      const response = await api.get('/api/Home/ObterClientes');
      setClientes(response.data);
    } catch (error) {
      console.error('Erro ao buscar clientes:', error);
      toast.error('Erro ao buscar clientes.');
    }
  }, []);

  const addCliente = async (cliente: Cliente) => {
    try {
      await api.post('/api/Home/AdicionarCliente', cliente);
      fetchClientes();
      toast.success('Cliente adicionado com sucesso!');
    } catch (error) {
      console.error('Erro ao adicionar cliente:', error);
      toast.error('Erro ao adicionar cliente.');
    }
  };

  const updateCliente = async (codigo: number, cliente: Partial<Cliente>) => {
    try {
      const payload = { ...cliente, codigo };
      console.log('Payload enviado para atualização:', payload); // Debug
      await api.put(`/api/Home/AtualizarCliente/${codigo}`, payload);
      fetchClientes();
      toast.success('Cliente atualizado com sucesso!');
    } catch (error) {
      console.error('Erro ao atualizar cliente:', error);
      toast.error('Erro ao atualizar cliente.');
    }
  };

  const deleteCliente = async (codigo: number) => {
    try {
      await api.delete(`/api/Home/DeletarCliente/${codigo}`);
      fetchClientes();
      toast.success('Cliente deletado com sucesso!');
    } catch (error) {
      console.error('Erro ao deletar cliente:', error);
      toast.error('Erro ao deletar cliente.');
    }
  };

  useEffect(() => {
    fetchClientes();
  }, [fetchClientes]); // Apenas dispara quando a função fetchClientes mudar

  return (
    <ClienteContext.Provider value={{ clientes, fetchClientes, addCliente, updateCliente, deleteCliente }}>
      {children}
    </ClienteContext.Provider>
  );
};
