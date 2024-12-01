import React, { createContext, ReactNode } from 'react';
import api from '../services/api';

// Tipos dos dados
type FretesAtendidos = {
    funcionario: string;
    empresa: string;
    representante: string;
    data_frete: string;
};

type FretesMedia = {
    cidade: string;
    estado: string;
    mediafreteorigem: number;
    mediafretedestino: number;
};

type FretesArrecadacao = {
    cidade: string;
    estado: string;
    quantidade_de_frete: number;
    valor_total_arrecadado: number;
};

// Tipos do contexto
type FreteContextType = {
    getFretesAtendidos: (mes: number, ano: number) => Promise<FretesAtendidos[]>;
    getFretesMedia: (id: number) => Promise<FretesMedia[]>;
    getFretesArrecadacao: (estado: string) => Promise<FretesArrecadacao[]>;
};

// Criando o contexto
export const FretesCalculosContext = createContext<FreteContextType | undefined>(undefined);

// Provider que irá envolver a aplicação
export const FretesCalculosProvider = ({ children }: { children: ReactNode }) => {

    // Função para buscar fretes atendidos
    const getFretesAtendidos = async (mes: number, ano: number) => {
        try {
            const response = await api.get(`/api/Home/ObterFuncionariosDePessoasJuridicasERepresentantes?mes=${mes}&ano=${ano}`);
            return response.data; // Retorna diretamente os dados sem armazenar no estado
        } catch (error) {
            console.error('Erro ao buscar fretes atendidos:', error);
            return [];
        }
    };

    // Função para buscar fretes media
    const getFretesMedia = async (id: number) => {
        try {
            const response = await api.get(`/api/Home/ObterMediaDeFretePorEstado/${id}`);
            return response.data; // Retorna diretamente os dados
        } catch (error) {
            console.error('Erro ao buscar médias de frete:', error);
            return [];
        }
    };

    // Função para buscar fretes arrecadacao
    const getFretesArrecadacao = async (estado: string) => {
        try {
            const response = await api.get(`/api/Home/ArrecadacaoComFretesPorEstado/${estado}`);
            return response.data; // Retorna diretamente os dados
        } catch (error) {
            console.error('Erro ao buscar arrecadação com fretes:', error);
            return [];
        }
    };

    return (
        <FretesCalculosContext.Provider value={{
            getFretesAtendidos,
            getFretesMedia,
            getFretesArrecadacao
        }}>
            {children}
        </FretesCalculosContext.Provider>
    );
};
