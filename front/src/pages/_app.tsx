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


function MyApp({ Component, pageProps }:AppProps) {
  return (
    <PessoaFisicaProvider>
    <FuncionarioProvider>
      <PessoaJuridicaProvider>
        <FreteProvider>
          <EstadoProvider>
            <CidadeProvider>
              <ClienteProvider>
              <Component {...pageProps} /> 
              <ToastContainer autoClose={3000}/>  
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
