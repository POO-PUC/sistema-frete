import { FC } from 'react';
import styles from './styles.module.scss';
import { Button } from '../ui/Button';
import { FaPlus } from 'react-icons/fa';


type FilterAndActionsProps = {
  searchTerm: string;
  setSearchTerm: (value: string) => void;
  buttonLabel: string;
  onButtonClick: () => void;
  additionalInputs?: {
    label: string;
    value: string | number;
    onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  }[]; 
};

const FilterAndActions: FC<FilterAndActionsProps> = ({
  searchTerm,
  setSearchTerm,
  buttonLabel,
  onButtonClick,
  additionalInputs = [],
}) => {
  return (
    <div className={styles.filterContainer}>
      {/* Campo de pesquisa */}
      <input
        type="text"
        placeholder="Search"
        className={styles.searchInput}
        value={searchTerm}
        onChange={(e) => setSearchTerm(e.target.value)}
      />

      {/* Renderização de inputs adicionais, se existirem */}
      {additionalInputs.length > 0 && (
        <div className={styles.additionalInputs}>
          {additionalInputs.map((input, index) => (
            <div key={index} className={styles.inputGroup}>
              <label>{input.label}</label>
              <input
                type="text"
                value={input.value}
                onChange={input.onChange}
                placeholder={input.label}
              />
            </div>
          ))}
        </div>
      )}

      {/* Botão de ação */}
      <Button
        className={styles.createButton}
        onClick={onButtonClick}
      >
        <FaPlus className={styles.plusIcon} /> {buttonLabel}
      </Button>
    </div>
  );
};

export default FilterAndActions;
