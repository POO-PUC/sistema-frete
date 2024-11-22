import { useState, useEffect } from 'react';
import { useRouter } from 'next/router';
import { useContext } from 'react';
import { FreteContext } from '../../../contexts/FreteContext';
import { CidadeContext } from '../../../contexts/CidadeContext';
import { ClienteContext } from '../../../contexts/ClienteContext';
import { FuncionarioContext } from '../../../contexts/FuncionarioContext';
import MainLayout from '../../../components/MainLayout';
import { Button } from '../../../components/ui/Button';
import { Select } from '../../../components/ui/Select';
import { Header } from '../../../components/Header';
import styles from './styles.module.scss';
import { toast } from 'react-toastify';

// Definir interfaces/types para os dados
type Cidade = {
  codigo: number;
  nome: string;
};

type Cliente = {
  codigo: number;
  endereco: string;
};

type Funcionario = {
  codigo: number;
  nome: string;
};

const CreateFrete = () => {
  const { addFrete } = useContext(FreteContext)!;
  const { cidades, fetchCidades } = useContext(CidadeContext)!;
  const { clientes, fetchClientes } = useContext(ClienteContext)!;
  const { funcionarios, fetchFuncionarios } = useContext(FuncionarioContext)!;

  const router = useRouter();

  // Estados locais usando os tipos definidos
  const [localCidades, setLocalCidades] = useState<Cidade[]>([]);
  const [localClientes, setLocalClientes] = useState<Cliente[]>([]);
  const [localFuncionarios, setLocalFuncionarios] = useState<Funcionario[]>([]);

  const [codigo, setCodigo] = useState<number | ''>(''); // Código do frete
  const [peso, setPeso] = useState('');
  const [valor, setValor] = useState('');
  const [icms, setIcms] = useState('');
  const [pedagio, setPedagio] = useState('');
  const [dataInicio, setDataInicio] = useState('');
  const [codigoDaCidadeDeOrigem, setCodigoDaCidadeDeOrigem] = useState('');
  const [codigoDaCidadeDeDestino, setCodigoDaCidadeDeDestino] = useState('');
  const [codigoDoCliente, setCodigoDoCliente] = useState('');
  const [codigoDoDestinatario, setCodigoDoDestinatario] = useState('');
  const [codigoDoFuncionario, setCodigoDoFuncionario] = useState('');
  const [quemPaga, setQuemPaga] = useState('');
  const [numeroDeConhecimento, setNumeroDeConhecimento] = useState('');
  const [loading, setLoading] = useState(false);

  // Carrega os dados apenas uma vez no início
  useEffect(() => {
    const loadInitialData = async () => {
      if (cidades.length === 0) {
        await fetchCidades();
      }
      if (clientes.length === 0) {
        await fetchClientes();
      }
      if (funcionarios.length === 0) {
        await fetchFuncionarios();
      }

      setLocalCidades(cidades);
      setLocalClientes(clientes);
      setLocalFuncionarios(funcionarios);
    };

    loadInitialData();
  }, [cidades, clientes, funcionarios, fetchCidades, fetchClientes, fetchFuncionarios]);

  const handleCreateFrete = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    try {
      if (!codigo || !codigoDaCidadeDeOrigem || !codigoDaCidadeDeDestino || !codigoDoFuncionario || !codigoDoCliente) {
        toast.error('Preencha todos os campos obrigatórios.');
        setLoading(false);
        return;
      }

      const formattedDataInicio = new Date(dataInicio).toISOString().split('T')[0];

      await addFrete({
        codigo,
        peso: parseFloat(peso),
        valor: parseFloat(valor),
        icms: parseFloat(icms),
        pedagio: parseFloat(pedagio),
        dataInicio: formattedDataInicio,
        codigoDaCidadeDeOrigem: parseInt(codigoDaCidadeDeOrigem),
        codigoDaCidadeDeDestino: parseInt(codigoDaCidadeDeDestino),
        codigoDoCliente: parseInt(codigoDoCliente),
        codigoDoDestinatario: parseInt(codigoDoDestinatario),
        codigoDoFuncionario: parseInt(codigoDoFuncionario),
        quemPaga,
        numeroDeConhecimento,
      });

      toast.success('Frete criado com sucesso!');
      router.push('/fretes');
    } catch (error) {
      console.error('Erro ao criar frete:', error);
      toast.error('Erro ao criar frete.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <MainLayout>
      <Header />
      <div className={styles.createFreteContainer}>
        <h1>Criar Novo Frete</h1>
        <form onSubmit={handleCreateFrete} className={styles.form}>
          <div className={styles.formGroup}>
            <label htmlFor="codigo">Código</label>
            <input
              id="codigo"
              type="number"
              value={codigo}
              onChange={(e) => setCodigo(Number(e.target.value))}
              required
            />
          </div>

          <div className={styles.formGroup}>
            <label htmlFor="peso">Peso</label>
            <input
              id="peso"
              type="number"
              step="0.01"
              value={peso}
              onChange={(e) => setPeso(e.target.value)}
              required
            />
          </div>

          <div className={styles.formGroup}>
            <label htmlFor="valor">Valor</label>
            <input
              id="valor"
              type="number"
              step="0.01"
              value={valor}
              onChange={(e) => setValor(e.target.value)}
              required
            />
          </div>

          <div className={styles.formGroup}>
            <label htmlFor="icms">ICMS</label>
            <input
              id="icms"
              type="number"
              step="0.01"
              value={icms}
              onChange={(e) => setIcms(e.target.value)}
              required
            />
          </div>

          <div className={styles.formGroup}>
            <label htmlFor="pedagio">Pedágio</label>
            <input
              id="pedagio"
              type="number"
              step="0.01"
              value={pedagio}
              onChange={(e) => setPedagio(e.target.value)}
              required
            />
          </div>

          <div className={styles.formGroup}>
            <label htmlFor="dataInicio">Data de Início</label>
            <input
              id="dataInicio"
              type="date"
              value={dataInicio}
              onChange={(e) => setDataInicio(e.target.value)}
              required
            />
          </div>

          <div className={styles.formGroup}>
            <label htmlFor="codigoDaCidadeDeOrigem">Cidade de Origem</label>
            <Select
              id="codigoDaCidadeDeOrigem"
              value={codigoDaCidadeDeOrigem}
              onChange={(e) => setCodigoDaCidadeDeOrigem(e.target.value)}
              required
            >
              <option value="">Selecione a cidade</option>
              {localCidades.map((cidade) => (
                <option key={cidade.codigo} value={cidade.codigo}>
                  {cidade.nome}
                </option>
              ))}
            </Select>
          </div>

          <div className={styles.formGroup}>
            <label htmlFor="codigoDaCidadeDeDestino">Cidade de Destino</label>
            <Select
              id="codigoDaCidadeDeDestino"
              value={codigoDaCidadeDeDestino}
              onChange={(e) => setCodigoDaCidadeDeDestino(e.target.value)}
              required
            >
              <option value="">Selecione a cidade</option>
              {localCidades.map((cidade) => (
                <option key={cidade.codigo} value={cidade.codigo}>
                  {cidade.nome}
                </option>
              ))}
            </Select>
          </div>

          <div className={styles.formGroup}>
            <label htmlFor="codigoDoCliente">Cliente</label>
            <Select
              id="codigoDoCliente"
              value={codigoDoCliente}
              onChange={(e) => setCodigoDoCliente(e.target.value)}
              required
            >
              <option value="">Selecione o cliente</option>
              {localClientes.map((cliente) => (
                <option key={cliente.codigo} value={cliente.codigo}>
                  {cliente.endereco}
                </option>
              ))}
            </Select>
          </div>

          <div className={styles.formGroup}>
            <label htmlFor="codigoDoDestinatario">Destinatário</label>
            <Select
              id="codigoDoDestinatario"
              value={codigoDoDestinatario}
              onChange={(e) => setCodigoDoDestinatario(e.target.value)}
              required
            >
              <option value="">Selecione o destinatário</option>
              {localClientes.map((cliente) => (
                <option key={cliente.codigo} value={cliente.codigo}>
                  {cliente.endereco}
                </option>
              ))}
            </Select>
          </div>

          <div className={styles.formGroup}>
            <label htmlFor="codigoDoFuncionario">Funcionário</label>
            <Select
              id="codigoDoFuncionario"
              value={codigoDoFuncionario}
              onChange={(e) => setCodigoDoFuncionario(e.target.value)}
              required
            >
              <option value="">Selecione o funcionário</option>
              {localFuncionarios.map((funcionario) => (
                <option key={funcionario.codigo} value={funcionario.codigo}>
                  {funcionario.nome}
                </option>
              ))}
            </Select>
          </div>

          <div className={styles.formGroup}>
            <label htmlFor="quemPaga">Quem Paga</label>
            <input
              id="quemPaga"
              type="text"
              value={quemPaga}
              onChange={(e) => setQuemPaga(e.target.value)}
              required
            />
          </div>

          <div className={styles.formGroup}>
            <label htmlFor="numeroDeConhecimento">Número de Conhecimento</label>
            <input
              id="numeroDeConhecimento"
              type="text"
              value={numeroDeConhecimento}
              onChange={(e) => setNumeroDeConhecimento(e.target.value)}
              required
            />
          </div>


          <Button type="submit" loading={loading}>
            Criar Frete
          </Button>
        </form>
      </div>
    </MainLayout>
  );
};

export default CreateFrete;
