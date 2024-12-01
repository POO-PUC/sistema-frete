import {AppProps } from 'next/app';
import '../../styles/globals.scss';
import 'react-toastify/dist/ReactToastify.css';
import {ToastContainer} from 'react-toastify'
import { EstadoProvider } from '../contexts/EstadoContext';
import { CidadeProvider } from '../contexts/CidadeContext';
import { ClienteProvider } from '../contexts/ClienteContext';
import { FuncionarioProvider } from "../contexts/FuncionarioContext";
import { PessoaFisicaProvider } from "../contexts/PessoaFisicaContext";
import { PessoaJuridicaProvider } from "../contexts/PessoaJuridicaContext";
import { FreteProvider } from "../contexts/FreteContext";
import { FretesCalculosProvider } from '@/contexts/FretesCalculosContext';


function MyApp({ Component, pageProps }:AppProps) {
  return (
    <PessoaFisicaProvider>
    <FuncionarioProvider>
      <PessoaJuridicaProvider>
        <FreteProvider>
          <EstadoProvider>
            <CidadeProvider>
              <ClienteProvider>
                <FretesCalculosProvider>
                  <Component {...pageProps} /> 
                  <ToastContainer autoClose={3000}/>  
                </FretesCalculosProvider>
              </ClienteProvider>
            </CidadeProvider>
          </EstadoProvider>
        </FreteProvider>
      </PessoaJuridicaProvider>
    </FuncionarioProvider>
    </PessoaFisicaProvider>
  ) 
}

export default MyApp
